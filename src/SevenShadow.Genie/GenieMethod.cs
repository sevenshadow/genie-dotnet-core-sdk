using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SevenShadow.Genie
{
    public enum GenieMethod
    {
        [Description("showStatus")]
        ShowStatus = 0,

        [Description("startModelLearning")]
        StartModelLearning = 1,

        [Description("stopModelLearning")]
        StopModelLearning = 2,

        [Description("observe")]
        Observe = 3,

        [Description("clearWM")]
        ClearSystemMemory = 4,

        [Description("getPredictions")]
        GetPredictions = 5,


        [Description("bulkLearning")]
        BulkLearning = 6,

        [Description("showPredictionsInfoBundle")]
        ShowPredictionsInfoBundle = 7,

        [Description("setPredictions")]
        SetPredictions = 8,

        [Description("clearAllMemory")]
        ClearAllMemory = 9,

        [Description("showTIC")]
        showTic = 10,

        [Description("ping")]
        Ping = 11,

        [Description("noAction")]
        NoAction = 12,


    }
}
