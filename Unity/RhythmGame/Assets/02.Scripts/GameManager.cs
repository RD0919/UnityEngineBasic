using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RhythmGame
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public GameManager() 
        {
            
        }
        public enum State
        {

            Idle,
            loadsongData,
            WaitUntilSongDataLoaded,
            StartGame,
            WaitUntilGameFinised,
            DisplayResult,
            WaitForUser
        }

        public State current;
        public string songSelected
        {
            get
            {
                return _songSelected;
            }
            set
            {
                _songSelected = value;
                onSongSelectedChanged?.Invoke(value);
            }
        }
        private string _songSelected;
        public event Action<string> onSongSelectedChanged;
        public float spped = 4.0f;

        public void PlayGame()
        {
            if (current != State.Idle)
                return;

            current ++;
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            //코드 기능 질문 필요!!
            
            
        }

        private void Update()
        {
            switch (current)
            {
                case State.Idle:
                    break;
                case State.loadsongData:
                    {
                        SondDataLoader.Load(_songSelected);
                        current++;
                    }
                    break;
                case State.WaitUntilSongDataLoaded:
                    {
                        SceneManager.LoadScene("Play");
                        current++;
                    }
                    break;
                case State.StartGame:
                    {
                        NoteSpawnManager.instance.StartSpawn();
                        current++;
                    }
                    break;
                case State.WaitUntilGameFinised:
                    break;
                case State.DisplayResult:
                    break;
                case State.WaitForUser:
                    break;
                default:
                    break;
            }
        }
    }
}

//static이 붙으면 힙 영역에 가지 않고 BSS, 