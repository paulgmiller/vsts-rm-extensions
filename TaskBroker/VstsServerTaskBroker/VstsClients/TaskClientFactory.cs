﻿using System;
using Microsoft.VisualStudio.Services.Common;

namespace VstsServerTaskHelper
{
    public class TaskClientFactory
    {
        public static ITaskClient GetTaskClient(Uri uri, string authToken, IBrokerInstrumentation instrumentationHandler, bool skipRaisePlanEvents)
        {
            var vssCrediential = new VssBasicCredential(string.Empty, authToken);

            return skipRaisePlanEvents ?
                new TaskClientNoopPlanEvent(uri, vssCrediential, instrumentationHandler) :
                new TaskClient(uri, vssCrediential, instrumentationHandler);
        }
    }
}
