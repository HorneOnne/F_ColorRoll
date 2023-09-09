using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace ColorRoll
{
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition, new Vector2(0, 0), 0.01f);
                DetectMouseClick _detectMouseClick;
                if(hits.Length == 1)
                {
                    if (hits[0].collider != null && hits[0].collider.TryGetComponent<DetectMouseClick>(out _detectMouseClick))
                    {
                        _detectMouseClick.Click();
                    }
                }
                else if(hits.Length > 1)
                {
                    int maxSortingOrder = int.MinValue; // Initialize with the smallest possible value
                    int indexOfMaxSortingOrder = -1; // Initialize with an invalid index

                    if (hits.Length > 0)
                    {
                        for (int i = 0; i < hits.Length; i++)
                        {
                            SpriteRenderer spriteRenderer = hits[i].collider.GetComponent<SpriteRenderer>();
                            if (spriteRenderer != null)
                            {
                                int sortingOrder = spriteRenderer.sortingOrder;
                                if (sortingOrder > maxSortingOrder)
                                {
                                    maxSortingOrder = sortingOrder;
                                    indexOfMaxSortingOrder = i; // Update the index of the max sorting order
                                }
                            }
                        }

                        if (indexOfMaxSortingOrder != -1)
                        {
                            Debug.Log("Largest Sorting Order: " + maxSortingOrder + " at index " + indexOfMaxSortingOrder);
                            if (hits[indexOfMaxSortingOrder].collider != null && hits[indexOfMaxSortingOrder].collider.TryGetComponent<DetectMouseClick>(out _detectMouseClick))
                            {
                                _detectMouseClick.Click();
                            }
                        }
                        else
                        {
                            Debug.Log("No SpriteRenderers found.");
                        }
                    }
                }
               
            }
        }
    }
}
