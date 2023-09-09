using System.Collections.Generic;
using UnityEngine;

namespace ColorRoll
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private List<Paper> _paperInSort = new List<Paper>();

        [SerializeField] private List<ListOfPaper> _winListOrder;

        private void OnEnable()
        {
            Paper.OnChangeState += SortInLayers;
        }

        private void OnDisable()
        {
            Paper.OnChangeState -= SortInLayers;
        }

        private void SortInLayers(Paper paper)
        {
            if (paper.PaperState == Paper.State.ON)
            {
                _paperInSort.Add(paper);
            }
            else
            {
                _paperInSort.Remove(paper);
            }

   
            for(int i = 0; i < _paperInSort.Count; i++)
            {
                _paperInSort[i].SpiteRenderer.sortingOrder = i + 1;
            }

            bool canWin = CheckWinCondition();
            if(canWin)
            {
                GameplayManager.Instance.ChangeGameState(GameplayManager.GameState.WIN);
            }
        }

        public bool CheckWinCondition()
        {
            foreach(var winList in _winListOrder) 
            { 
                if(ListsAreEqual(winList.Papers,_paperInSort))
                {
                    return true;
                }
            }

            return false;
        }


        private bool ListsAreEqual(List<Paper> a, List<Paper> b)
        {
            if (a.Count != b.Count)
            {
                return false;
            }

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] != b[i])
                {
                    return false; 
                }
            }

            return true;
        }
    }

    [System.Serializable]
    public class ListOfPaper
    {
        public List<Paper> Papers;
    }
}
