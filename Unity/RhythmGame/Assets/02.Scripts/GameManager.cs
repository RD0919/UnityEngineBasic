using System;
using UnityEngine;
using UnityEngine.SceneManagement;

//프로퍼퍼티 
namespace RhythmGame
{
    public class GameManager : MonoBehaviour //<- MonoBehavior는 오브젝트에 기능을 넣어주는거라 우리가 만들 수는 없다
    {
        public static GameManager instance
        {
            get 
            { 
                if(_instance == null)
                {
                    _instance = new GameObject().AddComponent<GameManager>();
                    DontDestroyOnLoad(_instance.gameObject);

                }
                return _instance;
            }
        }

        private static GameManager _instance;

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
            if (_instance != null)
            {
               Destroy(gameObject);
            }
           
            
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