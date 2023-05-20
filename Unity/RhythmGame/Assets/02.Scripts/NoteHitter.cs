using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;
using System;

namespace RhythmGame
{
    public class NoteHitter : MonoBehaviour
    {
        [SerializeField] private KeyCode _key;
        private SpriteRenderer _spriteRenderer;
        private Color _colorPressed;
        private Color _colorOrigin;
        [SerializeField] private LayerMask _targetMask;
        public event Action<HitJudge> onHit;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _colorOrigin = _spriteRenderer.color;
            _colorOrigin.a = 0.5f;
            _colorPressed = _colorOrigin;
            _colorPressed.a = 1.0f;
        }
        //질의(Query) : 특정 자료에서 원하는 자료를 탐색하거나, 취합하거나, 특정 조건에 따른 새로운 자료를 만드는 등의 행위를 말함

        private void Update()
        {
            if(Input.GetKeyDown(_key))
            {
                _spriteRenderer.color = _colorPressed;
                Hit();
            }
            else if (Input.GetKeyUp(_key))
            {
                _spriteRenderer.color = _colorOrigin;
                Hit();
            }
        }

        private void Hit()
        {
            HitJudge judge = HitJudge.None;
            Collider2D[] cols = Physics2D.OverlapBoxAll(point: transform.position, /*이 컴포넌트를 가지는 게임오브젝트의 transform 컴포넌트이다 */
                size: new Vector2(transform.lossyScale.x * 0.5f, Globals.HIT_JUDGE_RAHNGE_MISS), /*크기는 폭 : x(노트)의 반, 높이 : MISS의 크기 */
                angle: 0.0f, 
                layerMask: _targetMask);

            if (cols.Length > 0)
            {
                IOrderedEnumerable<Collider2D> colsFiltered = cols.OrderBy(x => Mathf.Abs(transform.position.y - x.transform.position.y));

                float distanse = Mathf.Abs(colsFiltered.First().transform.position.y - transform.position.y);

                if (distanse < Globals.HIT_JUDGE_RAHNGE_COOL / 2.0f)
                {
                    judge = HitJudge.Cool;
                    GameStatus.instance.coolCount++;
                }
                else if (distanse < Globals.HIT_JUDGE_RAHNGE_GREAT / 2.0f)
                {
                    judge = HitJudge.Great;
                    GameStatus.instance.greatCount++;
                }
                else if (distanse < Globals.HIT_JUDGE_RAHNGE_GOOD / 2.0f)
                {
                    judge = HitJudge.Good;
                    GameStatus.instance.goodCount++;
                }
                else if (distanse < Globals.HIT_JUDGE_RAHNGE_MISS / 2.0f)
                {
                    judge = HitJudge.Miss;
                    GameStatus.instance.missCount++;
                }
                else
                {
                    judge = HitJudge.Bad;
                    GameStatus.instance.badCount++;
                }
                Destroy(colsFiltered.First().gameObject);
                onHit?.Invoke(judge);
            }
        }
    }
}
