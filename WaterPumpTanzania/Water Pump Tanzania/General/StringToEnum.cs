namespace Water_Pump_Tanzania
{
    public static class StringToEnum
    {
        public static Status ToStatus(string value)
        {
            return value.ToLower() switch
            {
                "functional" => Status.Functional,
                "non functional" => Status.NonFunctional,
                "functional needs repair" => Status.NeedsRepair,
                _ => throw new ArgumentOutOfRangeException($"{value} is an unkown enum value of Status."),
            };
        }

        public static Waterpoint ToWaterpoint(string? value)
        {
            if (value == null) return Waterpoint.Unknown;
            return value.ToLower() switch
            {
                "communal standpipe" => Waterpoint.CommunalStandpipe,
                "hand pump" => Waterpoint.HandPump,
                "dam" => Waterpoint.Dam,
                "cattle trough" => Waterpoint.CattleTrough,
                "improved spring" => Waterpoint.ImprovedSpring,
                "other" => Waterpoint.Other,
                _ => Waterpoint.Unknown,
            };
        }

        public static SourceClass ToSourceClass(string? value)
        {
            if (value == null) return SourceClass.Unknown;
            return value.ToLower() switch
            {
                "groundwater" => SourceClass.Groundwater,
                "surface" => SourceClass.Surface,
                _ => SourceClass.Unknown
            };
        }

        public static Source ToSource(string? value)
        {
            if (value == null) return Source.Unknown;
            return value.ToLower() switch
            {
                "spring" => Source.Spring,
                "rainwater harvesting" => Source.RainwaterHarvesting,
                "dam" => Source.Dam,
                "machine dbh" => Source.MachineDbh,
                "borehole" => Source.BoreHole,
                "shallow well" => Source.ShallowWell,
                "river/lake" => Source.RiverOrLake,
                "river" => Source.River,
                "lake" => Source.Lake,
                "hand dtw" => Source.HandDtw,
                "other" => Source.Other,
                _ => Source.Unknown
            };
        }

        public static Quantity ToQuantity(string? value)
        {
            if (value == null) return Quantity.Unknown;
            return value.ToLower() switch
            {
                "enough" => Quantity.Enough,
                "insufficient harvesting" => Quantity.Insufficient,
                "dry" => Quantity.Dry,
                "seasonal" => Quantity.Seasonal,
                _ => Quantity.Unknown
            };
        }
        public static Quality ToQuality(string? value)
        {
            if (value == null) return Quality.Unknown;
            return value.ToLower() switch
            {
                "good" => Quality.Good,
                "salty" => Quality.Salty,
                "milky" => Quality.Milky,
                "fluoride" => Quality.Fluoride,
                "colored" => Quality.Colored,
                _ => Quality.Unknown
            };
        }

        public static WaterQuality ToWaterQuality(string? value)
        {
            if (value == null) return WaterQuality.Unknown;
            return value.ToLower() switch
            {
                "soft" => WaterQuality.Soft,
                "salty" => WaterQuality.Salty,
                "milky" => WaterQuality.Milky,
                "fluoride" => WaterQuality.Fluoride,
                "coloured" => WaterQuality.Coloured,
                "salty abandoned" => WaterQuality.SaltyAbandoned,
                "fluoride abandoned" => WaterQuality.FluorideAbandoned,
                _ => WaterQuality.Unknown
            };
        }

        public static PaymentType ToPaymentType(string? value)
        {
            if (value == null) return PaymentType.Unknown;
            return value.ToLower() switch
            {
                "annually" => PaymentType.Annually,
                "never pay" => PaymentType.NeverPay,
                "per bucket" => PaymentType.PerBucket,
                "on failure" => PaymentType.OnFailure,
                "soft" => PaymentType.Monthly,
                "monthly" => PaymentType.Other,
                _ => PaymentType.Unknown
            };
        }

        public static Payment ToPayment(string? value)
        {
            if (value == null) return Payment.Unknown;
            return value.ToLower() switch
            {
                "pay annually" => Payment.PayAnnually,
                "never pay" => Payment.NeverPay,
                "pay per bucket" => Payment.PayPerBucket,
                "pay when scheme fails" => Payment.PayWhenSchemeFails,
                "pay monthly" => Payment.PayMonthly,
                "other" => Payment.Other,
                _ => Payment.Unknown
            };
        }

        public static ManagementGroup ToManagementGroup(string? value)
        {
            if (value == null) return ManagementGroup.Unknown;
            return value.ToLower() switch
            {
                "user-group" => ManagementGroup.UserGroup,
                "commercial" => ManagementGroup.Commercial,
                "parastatal" => ManagementGroup.Parastatal,
                "other" => ManagementGroup.Other,
                _ => ManagementGroup.Unknown
            };
        }
       
        public static Management ToManagement(string? value)
        {
            if (value == null) return Management.Unknown;
            return value.ToLower() switch
            {
                "vwc" => Management.VWC,
                "wug" => Management.WUG,
                "private operator" => Management.PrivateOperator,
                "water board" => Management.WaterBoard,
                "wua" => Management.WUA,
                "swc" => Management.SWC,
                "company" => Management.Company,
                "water authority" => Management.WaterAuthority,
                "parastatal" => Management.Parastatal,
                "other - school" => Management.OtherSchool,
                "trust" => Management.Trust,
                "other" => Management.Other,
                "pay" => Management.None,
                _ => Management.Unknown
            };
        }

        public static Extraction ToExtraction(string? value)
        {
            if (value == null) return Extraction.Unknown;
            return value.ToLower() switch
            {
                "gravity" => Extraction.Gravity,
                "submersible" => Extraction.Submersible,
                "swn 80" => Extraction.SWN80,
                "other - swn 81" => Extraction.SWN81,
                "nira/tanira" => Extraction.NiraTanira,
                "india mark ii" => Extraction.IndiaMarkII,
                "india mark iii" => Extraction.IndiaMarkIII,
                "ksb" => Extraction.KSB,
                "mono" => Extraction.Mono,
                "windmill" => Extraction.Windmill,
                "wind-powered" => Extraction.WindPowered,
                "afridev" => Extraction.Afridev,
                "rope pump" => Extraction.RopePump,
                "other - rope pump" => Extraction.RopePump,
                "play pump" => Extraction.PlayPump,
                "other - play pump" => Extraction.PlayPump,
                "handpump" => Extraction.Handpump,
                "motorpump" => Extraction.Motorpump,
                "cemo" => Extraction.Cemo,
                "climax" => Extraction.Climax,
                "walimi" => Extraction.Walimi,
                "other - mkulima/shinyanga" => Extraction.MkulimaShinyanga,
                "other" => Extraction.Other,
                _ => Extraction.Unknown
            };
        }

        public static Basin ToBasin(string? value)
        {
            if (value == null) return Basin.Unknown;
            return value.ToLower() switch
            {
                "lake nyasa" => Basin.LakeNyasa,
                "lake victoria" => Basin.LakeVictoria,
                "pangani" => Basin.Pangani,
                "ruvuma / southern coast" => Basin.RuvumaSouthernCoast,
                "lake tanganyika" => Basin.LakeTanganyika,
                "wami / ruvu" => Basin.WamiRuvu,
                "rufiji" => Basin.Rufiji,
                "lake rukwa" => Basin.LakeRukwa,
                "internal" => Basin.Internal,
                _ => Basin.Unknown
            };
        }
    }
}
