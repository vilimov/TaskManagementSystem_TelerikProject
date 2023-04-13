﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Model.Enum;

namespace Team.Model.Interface
{
    public interface IFeedback : ITask
    {
        FeedbackStatus StatusType { get; }
        int Rating { get; }
    } 
}
