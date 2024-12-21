using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleProject.Tools
{
    public class Helpers : MonoBehaviour
    {
        #region Screen
        public static bool IsWideScreen()
        {
            return GetScreenRatio() > 16f / 9f;
        }
        public static bool IsLongScreen()
        {
            return GetScreenRatio() < 9f / 16f;
        }
        public static float GetScreenRatio()
        {
            return (float)Camera.main.pixelWidth / (float)Camera.main.pixelHeight;
        }
        #endregion

        #region Transform
        public static void DestroyAllChilds(Transform go)
        {
            for (int i = go.childCount - 1; i >= 0; i--)
            {
                Destroy(go.GetChild(i).gameObject);
            }
        }
        public static void RecycleAllChilds(GameObject go)
        {
            for (int i = go.transform.childCount - 1; i >= 0; i--)
            {
                ObjectPool.Recycle(go.transform.GetChild(i).gameObject);
            }
        }
        #endregion

        #region Format String
        public static string FormatTime(float _time)
        {
            int _minutes = Mathf.FloorToInt(_time / 60f);
            int _seconds = Mathf.FloorToInt(_time % 60f);
            return string.Format("{0:00}:{1:00}", _minutes, _seconds);
        }
        public static string FormatTimev2(TimeSpan _timeSpan)
        {
            return string.Format("{0:D2}:{1:D2}:{2:D2}", _timeSpan.Hours, _timeSpan.Minutes, _timeSpan.Seconds);
        }
        #endregion

        #region Random
        public static T GetRandomEnum<T>(T _min, T _max)
        {
            Array A = Enum.GetValues(typeof(T));
            T V = (T)A.GetValue(UnityEngine.Random.Range((int)(object)_min, (int)(object)_max));
            return V;
        }
        public static int RandomByWeight(float[] probs)
        {

            float total = 0;

            foreach (float elem in probs)
            {
                total += elem;
            }

            float randomPoint = UnityEngine.Random.value * total;

            for (int i = 0; i < probs.Length; i++)
            {
                if (randomPoint < probs[i])
                {
                    return i;
                }
                else
                {
                    randomPoint -= probs[i];
                }
            }
            return probs.Length - 1;
        }
        public static void Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = UnityEngine.Random.Range(0, n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        #endregion

        #region Algorithm
        public static List<int> CalculatePyramid(int number)
        {
            List<int> list = new List<int>();
            int index = 0;
            for (int i = 0; i < Mathf.Infinity; i++)
            {
                if (i % 2 == 0)
                {
                    index++;
                    if (number >= index)
                    {
                        number -= index;
                        list.Add(index);
                    }
                    else
                    {
                        if (number == 0)
                            break;
                        else
                        {
                            list.Insert(number * 2, number);
                            number = 0;
                        }
                        break;
                    }
                }
                else
                {
                    if (number >= index)
                    {
                        number -= index;
                        list.Add(index);
                    }
                    else
                    {
                        if (number == 0)
                            break;
                        else
                        {
                            list.Insert(number * 2, number);
                            number = 0;
                        }
                        break;
                    }
                }
            }
            return list;
        }
        public static int Fibonacci(int n)
        {
            if (n <= 0)
                return 1;
            if (n == 1)
                return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        public static List<int> SolveMinimumCoinExchange(List<int> coinValues, int targetValue)
        {
            coinValues.Sort();

            List<int> coinsUsed = new List<int>(); // list to store the coins used
            int remainingValue = targetValue; // remaining value to be reached

            // iterate through the coin values from highest to lowest
            for (int i = coinValues.Count - 1; i >= 0; i--)
            {
                // check if the coin value is less than or equal to the remaining value
                while (coinValues[i] <= remainingValue)
                {
                    coinsUsed.Add(coinValues[i]); // add the coin to the list of coins used
                    remainingValue -= coinValues[i]; // subtract the coin value from the remaining value
                }
            }

            return coinsUsed; // return the list of coins used
        }
        #endregion

        #region UI
        public static Vector3 WorldToLocalPointInRectangle(Vector3 _worldPosition, Canvas _canvasParent)
        {
            // Convert the world position to screen space
            Vector2 _screenPosition = Camera.main.WorldToScreenPoint(_worldPosition);

            // Convert the screen position to canvas local position
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasParent.transform as RectTransform, _screenPosition, _canvasParent.worldCamera, out Vector2 _localPosition);
            return _localPosition;
        }
        public static void SetLeftRightTopBottom(RectTransform _rtf, float _left,
            float _right, float _top, float _bottom)
        {
            _rtf.offsetMin = new Vector2(_left, _rtf.offsetMin.y);
            _rtf.offsetMax = new Vector2(-_right, _rtf.offsetMax.y);
            _rtf.offsetMax = new Vector2(_rtf.offsetMax.x, -_top);
            _rtf.offsetMin = new Vector2(_rtf.offsetMin.x, _bottom);
        }
        public static void SetLeft(RectTransform _rtf, float _left)
        {
            _rtf.offsetMin = new Vector2(_left, _rtf.offsetMin.y);
        }
        public static void SetRight(RectTransform _rtf, float _right)
        {
            _rtf.offsetMax = new Vector2(-_right, _rtf.offsetMax.y);
        }
        public static void SetTop(RectTransform _rtf, float _top)
        {
            _rtf.offsetMax = new Vector2(_rtf.offsetMax.x, -_top);
        }
        public static void SetBottom(RectTransform _rtf, float _bottom)
        {
            _rtf.offsetMin = new Vector2(_rtf.offsetMin.x, _bottom);
        }
        #endregion

        #region Raycast
        public static bool TryGetMousePostionOnCollider(Ray _ray, LayerMask _mask, out RaycastHit _raycastHit)
        {
            if (Physics.Raycast(_ray, out RaycastHit _raycastHitPoint, Mathf.Infinity, _mask))
            {
                _raycastHit = _raycastHitPoint;
                return true;
            }
            else
            {
                _raycastHit = new RaycastHit();
                return false;
            }
        }
        public static bool TryGetMousePostionOnPlane(Ray _ray, Plane _plane, out Vector3 _hitPoint)
        {
            if (_plane.Raycast(_ray, out float enter))
            {
                _hitPoint = _ray.GetPoint(enter);
                return true;
            }
            else
            {
                _hitPoint = Vector3.zero;
                return false;
            }
        }
        #endregion

        #region Get Somethings
        public static List<T> GetAllChildsComponent<T>(Transform _parent)
        {
            List<T> _l = new List<T>();
            foreach (Transform _child in _parent.GetComponentsInChildren<Transform>(true))
            {
                if (_child.GetComponent<T>() != null)
                    _l.Add(_child.GetComponent<T>());
            }
            return _l;
        }
        public static List<T> GetAllEnum<T>()
        {

            List<T> enumValues = new();
            foreach (T value in Enum.GetValues(typeof(T)))
            {
                enumValues.Add(value);
            }
            return enumValues;
        }
        #endregion
    }
}