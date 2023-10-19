using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Water_Pump_Tanzania
{
    public enum Status
    {
        Functional,
        NonFunctional,
        NeedsRepair,
    }

    public enum Waterpoint
    {
        CommunalStandpipe,
        HandPump,
        Dam,
        CattleTrough,
        ImprovedSpring,
        Other,
        Unknown,
    }
    
    public enum SourceClass
    {
        Groundwater,
        Surface,
        Unknown,
    }

    public enum Source
    {
        Spring,
        RainwaterHarvesting,
        Dam,
        MachineDbh,
        BoreHole,
        ShallowWell,
        RiverOrLake,
        River,
        Lake,
        HandDtw,
        Other,
        Unknown,
    }

    public enum Quantity
    {
        Enough,
        Insufficient,
        Dry,
        Seasonal,
        Unknown,
    }

    public enum Quality
    {
        Good,
        Salty,
        Milky,
        Fluoride,
        Colored,
        Unknown,
    }

    public enum WaterQuality
    {
        Soft,
        Salty,
        Milky,
        Fluoride,
        Coloured,
        SaltyAbandoned,
        FluorideAbandoned,
        Unknown,
    }

    public enum PaymentType
    {
        Annually,
        NeverPay,
        PerBucket,
        OnFailure,
        Monthly,
        Other,
        Unknown,
    }

    public enum Payment
    {
        PayAnnually,
        NeverPay,
        PayPerBucket,
        PayWhenSchemeFails,
        PayMonthly,
        Other,
        Unknown,
    }

    public enum ManagementGroup
    {
        UserGroup,
        Commercial,
        Parastatal,
        Other,
        Unknown,
    }

    public enum Management
    {
        VWC,
        WUG,
        PrivateOperator,
        WaterBoard,
        WUA,
        SWC,
        Company,
        WaterAuthority,
        Parastatal,
        OtherSchool,
        Trust,
        Other,
        None,
        Unknown,
    }

    public enum Extraction
    {
        Gravity,
        Submersible,
        SWN80,
        SWN81,
        NiraTanira,
        IndiaMarkII,
        IndiaMarkIII,
        KSB,
        Mono,
        Windmill,
        WindPowered,
        Afridev,
        RopePump,
        PlayPump,
        Handpump,
        Motorpump,
        Cemo,
        Climax,
        Walimi,
        MkulimaShinyanga,
        Other,
        Unknown,
    }

    public enum Basin
    {
        LakeNyasa,
        LakeVictoria,
        Pangani,
        RuvumaSouthernCoast,
        LakeTanganyika,
        WamiRuvu,
        Rufiji,
        LakeRukwa,
        Internal,
        Unknown,
    }

}
