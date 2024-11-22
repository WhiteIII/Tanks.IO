using UnityEngine;
using UnityEngine.UI;
using TanksIO.Common.Core.Enemy;
using TanksIO.Common.Services;
using TanksIO.Common.ScriptableObjects;

namespace TanksIO.UI
{
    public class EntityHealthBarFactory
    {
        public void CreateCanvasForTarget(GameObject gameObject, EntityHealth entityHealth, 
            UIElementsListData uIElementsListData, EnemyCanvasAnimation enemyCanvasAnimation)
        {
            Canvas canvas;

            var canvasGameObject = new GameObject("EnemyCanvas");

            canvas = canvasGameObject.AddComponent<Canvas>();
            canvasGameObject.AddComponent<CanvasLookedOnCamera>().Init(Camera.main, enemyCanvasAnimation);
            canvasGameObject.AddComponent<EntityHealthBarController>().Init(canvasGameObject, entityHealth);

            canvas.renderMode = RenderMode.WorldSpace;

            canvasGameObject.transform.SetParent(gameObject.transform);

            canvas.GetComponent<RectTransform>().localPosition = new Vector3(0, 1.3f, 0);
            canvas.GetComponent<RectTransform>().sizeDelta = new Vector2(1, 1);
            canvas.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            CreateHealthBar(canvasGameObject, entityHealth, uIElementsListData);
        }

        private void CreateHealthBar(GameObject canvasGameObject, EntityHealth entityHealth, 
            UIElementsListData uIElementsListData)
        {
            Image imageHealthBar;
            Image imageBackGround;
            EntityHealthBar healthBar;

            var healthBarGameObject = new GameObject("HealthBar");
            var backGroundGameObject = new GameObject("BackGround");

            imageHealthBar = healthBarGameObject.AddComponent<Image>();
            imageBackGround = backGroundGameObject.AddComponent<Image>();

            imageBackGround.color = Color.white;
            imageBackGround.raycastTarget = false;

            imageHealthBar.sprite = uIElementsListData.List[0];
            imageHealthBar.color = Color.red;
            imageHealthBar.type = Image.Type.Filled;
            imageHealthBar.fillMethod = Image.FillMethod.Horizontal;
            imageHealthBar.fillOrigin = 1;
            imageHealthBar.raycastTarget = false;

            backGroundGameObject.transform.SetParent(canvasGameObject.transform);
            healthBarGameObject.transform.SetParent(canvasGameObject.transform);

            healthBar = healthBarGameObject.AddComponent<EntityHealthBar>();
            healthBar.Init(entityHealth, imageHealthBar);

            imageBackGround.rectTransform.localPosition = new Vector3(0, -0.157f, 0);
            imageBackGround.rectTransform.sizeDelta = new Vector2(1, 0.1f);
            imageBackGround.rectTransform.localScale = new Vector3(1, 1, 1);

            imageHealthBar.rectTransform.localPosition = new Vector3(0, -0.157f, 0);
            imageHealthBar.rectTransform.sizeDelta = new Vector2(0.97f, 0.07f);
            imageHealthBar.rectTransform.localScale = new Vector3(1, 1, 1);
        }
    }
}