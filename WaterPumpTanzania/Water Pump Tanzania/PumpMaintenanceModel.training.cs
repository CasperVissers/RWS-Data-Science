﻿﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.LightGbm;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using Microsoft.ML;

namespace Water_Pump_Tanzania
{
    public partial class PumpMaintenanceModel
    {
        /// <summary>
        /// Retrains model using the pipeline generated as part of the training process. For more information on how to load data, see aka.ms/loaddata.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="trainData"></param>
        /// <returns></returns>
        public static ITransformer RetrainPipeline(MLContext mlContext, IDataView trainData)
        {
            var pipeline = BuildPipeline(mlContext);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(new []{new InputOutputColumnPair(@"basin", @"basin"),new InputOutputColumnPair(@"extraction_type_class", @"extraction_type_class"),new InputOutputColumnPair(@"management_group", @"management_group"),new InputOutputColumnPair(@"water_quality", @"water_quality"),new InputOutputColumnPair(@"quantity_group", @"quantity_group"),new InputOutputColumnPair(@"source_type", @"source_type"),new InputOutputColumnPair(@"waterpoint_type_group", @"waterpoint_type_group")}, outputKind: OneHotEncodingEstimator.OutputKind.Indicator)      
                                    .Append(mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"amount_tsh", @"amount_tsh"),new InputOutputColumnPair(@"gps_height", @"gps_height"),new InputOutputColumnPair(@"population", @"population"),new InputOutputColumnPair(@"construction_year", @"construction_year")}))      
                                    .Append(mlContext.Transforms.Conversion.ConvertType(new []{new InputOutputColumnPair(@"public_meeting", @"public_meeting"),new InputOutputColumnPair(@"permit", @"permit")}))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"basin",@"extraction_type_class",@"management_group",@"water_quality",@"quantity_group",@"source_type",@"waterpoint_type_group",@"amount_tsh",@"gps_height",@"population",@"construction_year",@"public_meeting",@"permit"}))      
                                    .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName:@"status_group",inputColumnName:@"status_group"))      
                                    .Append(mlContext.MulticlassClassification.Trainers.LightGbm(new LightGbmMulticlassTrainer.Options(){NumberOfLeaves=124,NumberOfIterations=4,MinimumExampleCountPerLeaf=49,LearningRate=0.999999776672986,LabelColumnName=@"status_group",FeatureColumnName=@"Features",ExampleWeightColumnName=null,Booster=new GradientBooster.Options(){SubsampleFraction=0.124398383675623,FeatureFraction=0.99999999,L1Regularization=8.67528769499374E-09,L2Regularization=0.999999776672986},MaximumBinCountPerFeature=307}))      
                                    .Append(mlContext.Transforms.Conversion.MapKeyToValue(outputColumnName:@"PredictedLabel",inputColumnName:@"PredictedLabel"));

            return pipeline;
        }
    }
}
