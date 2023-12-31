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

namespace PumpMaintenanceModel_Prediction
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
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(new []{new InputOutputColumnPair(@"installer", @"installer"),new InputOutputColumnPair(@"scheme_management", @"scheme_management"),new InputOutputColumnPair(@"extraction_type", @"extraction_type"),new InputOutputColumnPair(@"extraction_type_class", @"extraction_type_class"),new InputOutputColumnPair(@"management", @"management"),new InputOutputColumnPair(@"management_group", @"management_group"),new InputOutputColumnPair(@"quality_group", @"quality_group"),new InputOutputColumnPair(@"quantity_group", @"quantity_group"),new InputOutputColumnPair(@"source_type", @"source_type"),new InputOutputColumnPair(@"source_class", @"source_class"),new InputOutputColumnPair(@"waterpoint_type", @"waterpoint_type")}, outputKind: OneHotEncodingEstimator.OutputKind.Indicator)      
                                    .Append(mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"amount_tsh", @"amount_tsh"),new InputOutputColumnPair(@"gps_height", @"gps_height"),new InputOutputColumnPair(@"longitude", @"longitude"),new InputOutputColumnPair(@"latitude", @"latitude"),new InputOutputColumnPair(@"region_code", @"region_code"),new InputOutputColumnPair(@"district_code", @"district_code"),new InputOutputColumnPair(@"population", @"population"),new InputOutputColumnPair(@"construction_year", @"construction_year")}))      
                                    .Append(mlContext.Transforms.Conversion.ConvertType(new []{new InputOutputColumnPair(@"public_meeting", @"public_meeting"),new InputOutputColumnPair(@"permit", @"permit")}))      
                                    .Append(mlContext.Transforms.Conversion.ConvertType(@"date_recorded", @"date_recorded"))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"installer",@"scheme_management",@"extraction_type",@"extraction_type_class",@"management",@"management_group",@"quality_group",@"quantity_group",@"source_type",@"source_class",@"waterpoint_type",@"amount_tsh",@"gps_height",@"longitude",@"latitude",@"region_code",@"district_code",@"population",@"construction_year",@"public_meeting",@"permit",@"date_recorded"}))      
                                    .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName:@"status_group",inputColumnName:@"status_group"))      
                                    .Append(mlContext.MulticlassClassification.Trainers.LightGbm(new LightGbmMulticlassTrainer.Options(){NumberOfLeaves=6,NumberOfIterations=57,MinimumExampleCountPerLeaf=31,LearningRate=0.999999776672986,LabelColumnName=@"status_group",FeatureColumnName=@"Features",ExampleWeightColumnName=null,Booster=new GradientBooster.Options(){SubsampleFraction=0.00142289302200839,FeatureFraction=0.929015216042686,L1Regularization=2.88283340450437E-10,L2Regularization=0.999999776672986},MaximumBinCountPerFeature=184}))      
                                    .Append(mlContext.Transforms.Conversion.MapKeyToValue(outputColumnName:@"PredictedLabel",inputColumnName:@"PredictedLabel"));

            return pipeline;
        }
    }
}
