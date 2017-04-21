﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Models.Constants
{
    internal static class AdminMessages
    {
        internal const string RequiredFieldMessage = "Полето е задължително";

        internal const string NameLenghtMessage = "Името трябва да е между {2} и {1} символа";

        internal const string DescriptionLenghtMessage = "Описаниeто трябва да е между {2} и {1} символа";

        internal const string UsernameLengthMessage = "Потребителското име трябва да е между {2} и {1} символа";

        internal const string PasswordLengthMessage = "Паралота трябва да бъде поне {2} символа";

        internal const string ContentLengthMessage = "Съобщението трябва да е между {2} и {1} символа";

        internal const string SubjectLengthMessage = "Темата трябва да е между {2} и {1} символа";

        internal const int MinProductNameLegnth = 2;

        internal const int MaxProductNameLegnth = 255;

        internal const int MinEventNameLegnth = 5;

        internal const int MaxEventNameLegnth = 50;

        internal const int MinEventDescriptionLegnth = 20;

        internal const int MaxEventDescriptionLegnth = 500;

        internal const int MinContentLegnth = 10;

        internal const int MaxContentLegnth = 500;

        internal const int MinSubjectLegnth = 5;

        internal const int MaxSubjectLegnth = 50;
    }
}
