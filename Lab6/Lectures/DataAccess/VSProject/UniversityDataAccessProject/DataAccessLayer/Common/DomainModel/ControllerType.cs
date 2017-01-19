﻿namespace DataAccessLayer.Common.DomainModel
{
    using System.Collections.Generic;

    public class ControllerType : IEntity
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int Category { get; set; }

        public int HardwareIndex { get; set; }

        public int SoftwareIndexMin { get; set; }

        public int SoftwareIndexMax { get; set; }

        public IList<Datapoint> Datapoints { get; set; }
    }
}
