using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enums
{
    public enum JobStatuses
    {
        JobCreated = 1,
        PickedUp = 2,
        OnSite = 3,
        Completed = 4
    }

    public enum EventTypes
    {
        JobCreated = 1,
        JobPickedUp = 2,
        JobTechnicianOnSite = 3,
        JobTechnicianDropped = 4,
        JobTechnicianCompleted = 5,
        TestEventType = 6
    }

    public enum QuoteTypes
    {
        DesktopQuote = 1,
        SurveyQuote = 2
    }

    public enum QuoteStatuses
    {
        QuoteCreated = 1,
        SurveyScheduled = 2,
        Completed = 3
    }
}
