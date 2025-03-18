using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowflakeIdGen
{
    public class SnowflakeGenerator
    {
        private static long Epoch = 1288834974657L; // Twitter's epoch (2010-01-01 00:00:00)
        //private static long Epoch = new DateTimeOffset(new DateTime(2025, 1, 1)).ToUnixTimeMilliseconds();

        private static readonly int MachineIdBits = 10; // Bits for machine ID (Worker ID)
        private static readonly int SequenceBits = 12; // Bits for sequence number
        private static readonly long MaxMachineId = -1L ^ (-1L << MachineIdBits); // Max value for machine ID
        private static readonly long SequenceMask = -1L ^ (-1L << SequenceBits); // Max value for sequence number
        private static readonly int MachineIdShift = SequenceBits; // How much to shift sequence bits
        private static readonly int TimestampShift = SequenceBits + MachineIdBits; // How much to shift machine bits

        private long _machineId; // Machine ID
        private long _sequence = 0L; // Sequence number
        private long _lastTimestamp = -1L; // Last timestamp

        public SnowflakeGenerator(long machineId)
        {
            if (machineId > MaxMachineId || machineId < 0)
                throw new ArgumentException($"Machine ID must be between 0 and {MaxMachineId}");
            _machineId = machineId;
        }

        public long GenerateId()
        {
            lock (this)
            {
                long timestamp = GetCurrentTimestamp();

                if (timestamp != _lastTimestamp)
                {
                    _sequence = 0;
                    _lastTimestamp = timestamp;
                }
                else if (_sequence < SequenceMask)
                {
                    _sequence++;
                }
                else
                {
                    timestamp = WaitForNextMillis(_lastTimestamp);
                    _lastTimestamp = timestamp;
                    _sequence = 0;
                }

                long snowflakeId = ((timestamp - Epoch) << TimestampShift) | (_machineId << MachineIdShift) | _sequence;
                return snowflakeId;
            }
        }

        private long GetCurrentTimestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        private long WaitForNextMillis(long lastTimestamp)
        {
            long timestamp = GetCurrentTimestamp();
            while (timestamp <= lastTimestamp)
            {
                timestamp = GetCurrentTimestamp();
            }
            return timestamp;
        }
    }
}
