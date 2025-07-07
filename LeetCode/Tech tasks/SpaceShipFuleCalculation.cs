using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tech_tasks
{
    public class SpaceShipFuelCalculation
    {
        private static Dictionary<TargetSpaceObject, float> gravityDict = new Dictionary<TargetSpaceObject, float>()
        {
            { TargetSpaceObject.Earth, 9.807f },
            { TargetSpaceObject.Moon, 1.62f },
            { TargetSpaceObject.Mars, 3.711f }
        };
        public static int Process(double mass, List<Destination> stations)
        {
            double fullMass = mass;

            stations.Reverse();

            foreach (var station in stations)
            {
                float gravity = gravityDict[station.TargetSpaceObject];

                double iterationMass = fullMass;

                do
                {
                    iterationMass = CalculateFuel(iterationMass, gravity, station.OperationType);
                    fullMass += iterationMass;
                }
                while (iterationMass > 0);
            }

            return (int)(fullMass - mass);
        }

        private static double CalculateFuel(double mass, float gravity, OperationType operationType)
        {
            double fuel = 0;

            switch (operationType)
            {
                case OperationType.Launch:
                    fuel = (mass * gravity * 0.042) - 33;
                    break;
                case OperationType.Land:
                    fuel = (mass * gravity * 0.033) - 42;
                    break;
                default:
                    break;
            }

            return fuel > 0 ? (int)Math.Floor(fuel) : 0;
        }

    }
    public enum TargetSpaceObject
    {
        Earth,
        Moon,
        Mars
    }
    public enum OperationType
    {
        Launch,
        Land
    }
    public class Destination
    {
        public OperationType OperationType { get; set; }
        public TargetSpaceObject TargetSpaceObject { get; set; }
    }
}
