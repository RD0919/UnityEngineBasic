using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmGame
{
    public static class Globals
    {
        public const int SCORE_COOL = 500;
        public const int SCORE_GREAT = 300;
        public const int SCORE_GOOD = 100;
        public const int SCORE_MISS = 500;
        public const int SCORE_BAD = -100;

        public const float HIT_JUDGE_RAHNGE_COOL = 0.7f;
        public const float HIT_JUDGE_RAHNGE_GREAT = 1.0f;
        public const float HIT_JUDGE_RAHNGE_GOOD = 1.8f;
        public const float HIT_JUDGE_RAHNGE_MISS = 3.0f;

    }

    public enum HitJudge
    {
        None,
        Bad,
        Miss,
        Good,
        Great,
        Cool

    }

}
