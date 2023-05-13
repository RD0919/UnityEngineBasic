using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmGame
{
    internal class SongSelectButton : MonoBehaviour //monaBehaviour가 뭔지 질문
    {
        [SerializeField] private string _songName;
        private void Start()
        {
            GetComponent<Button>()
                .onClick
                .AddListener(() => GameManager.instance.songSelected = _songName);
        }
    }
}
