using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using System;
///일반적인 싱글톤 패턴
///static instanse 참조변수 접근시 해당 변수가 null이면
///인스턴스를 새로 생성해서 참조를 반환해줌.

namespace RhythmGame
{
    public class GameStatus
    {
        public static GameStatus instance
        {
            get
            {
                if (_instanse == null)
                    _instanse = new GameStatus();
                return _instanse;
            }
        }

        public static GameStatus _instanse;
        public int currentCombo
        {
            get => _currentCombo;
            set 
            {
                _currentCombo = value;
                onCurrentComboChanged?.Invoke(value);
            }
        }
        private int _currentCombo;
        public event Action<int> onCurrentComboChanged;

        public int score
        {
            get => _score;
            set 
            {
                _score = value;
                onScoreChanged?.Invoke(value);//<- 간접적으로 호출한다.
            }
        }
        private int _score;
        private event Action<int> onScoreChanged;

        public int coolCount
        {
            get => _coolCount;
            set
            {
                int diff = value - _coolCount;
                value = _coolCount;
                if(diff > 0)
                    currentCombo += diff;
                score += diff * Globals.SCORE_COOL;
            }
        }
        private int _coolCount;

        public int greatCount
        {
            get => _greatCount;
            set
            {
                int diff = value - _greatCount;
                value = _greatCount;
                if (diff > 0)
                    currentCombo += diff;
                score += diff * Globals.SCORE_GREAT;
            }
        }
        private int _greatCount;

        public int goodCount
        {
            get => _goodCount;
            set
            {
                int diff = value - _goodCount;
                value = _goodCount;
                if (diff > 0)
                    currentCombo += diff;
                score += diff * Globals.SCORE_GOOD;
            }
        }
        private int _goodCount;

        public int missCount
        {
            get => _missCount;
            set
            {
                int diff = value - _missCount;
                value = _missCount;
                currentCombo = 0;
                score += diff * Globals.SCORE_MISS;
            }
        }
        private int _missCount;

        public int badCount
        {
            get => _badCount;
            set
            {
                int diff = value - _badCount;
                value = _badCount;
                currentCombo = 0;
                score += diff * Globals.SCORE_BAD;
            }
        }
        private int _badCount;
    }
}
