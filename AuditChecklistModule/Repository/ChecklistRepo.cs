using AuditChecklistModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditChecklistModule.Repository
{
    public class ChecklistRepo : IChecklistRepo
    {
        
        readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ChecklistRepo));

        private static List<Questions> InternalQuestionsList = new List<Questions>()
        {
            new Questions
            {
                QuestionNo=1,
                Question="Have all Change requests followed SDLC before PROD move?"
            },
            new Questions
            {
                QuestionNo=2,
                Question="Have all Change requests been approved by the application owner?"
            },
            new Questions
            {
                QuestionNo=3,
                Question="Are all artifacts like CR document, Unit test cases available?"
            },
            new Questions
            {
                QuestionNo=4,
                Question="Is the SIT and UAT sign-off available?"
            },
            new Questions
            {
                QuestionNo=5,
                Question="Is data deletion from the system done with application owner approval?"
            }
        };

        private static List<Questions> SOXQuestionsList = new List<Questions>()
        {
            new Questions
            {
                QuestionNo=1,
                Question="Have all Change requests followed SDLC before PROD move?"
            },
            new Questions
            {
                QuestionNo=2,
                Question="Have all Change requests been approved by the application owner?"
            },
            new Questions
            {
                QuestionNo=3,
                Question="For a major change, was there a database backup taken before and after PROD move?"
            },
            new Questions
            {
                QuestionNo=4,
                Question="Has the application owner approval obtained while adding a user to the system?"
            },
            new Questions
            {
                QuestionNo=5,
                Question="Is data deletion from the system done with application owner approval?"
            }
        };


        public List<Questions> GetQuestions(string auditType)
        {
            try
            {
                _log4net.Info("Log from " + nameof(ChecklistRepo));
                List<Questions> listOfQuestions = new List<Questions>();

                if (auditType == "Internal")
                    listOfQuestions = InternalQuestionsList;
                else
                    listOfQuestions = SOXQuestionsList;

                return listOfQuestions;
            }
            catch (Exception e)
            {
                _log4net.Error("Exception " + e.Message + nameof(ChecklistRepo));
                return null;

            }

        }

    }
}
