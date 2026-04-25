using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shared.DataTransferObjects.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shared.HelperMethods
{
    public class JsonHelperMethods
    {
        public static string? ExtractJson(string raw)
        {
            var match = Regex.Match(raw, @"\{[\s\S]*\}");
            return match.Success ? match.Value.Trim() : null;
        }

        public static bool IsValidJson(string json, out string? error)
        {
            try
            {
                JToken.Parse(json);
                error = null;
                return true;
            }
            catch (JsonReaderException ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public static bool IsValidAiTest(TestAIDto test, out string reason)
        {
            if (string.IsNullOrWhiteSpace(test.TestName))
            {
                reason = "Missing testName";
                return false;
            }

            if (test.Exercises.Count != 4)
            {
                reason = "Test must contain exactly 4 exercises";
                return false;
            }

            foreach (var ex in test.Exercises)
            {
                if (ex.Answers.Count < 2)
                {
                    reason = "Each exercise must have at least 2 answers";
                    return false;
                }

                if (ex.Answers.All(a => !a.IsCorrect))
                {
                    reason = "Each exercise must have at least one correct answer";
                    return false;
                }
            }

            reason = string.Empty;
            return true;
        }

    }
}
