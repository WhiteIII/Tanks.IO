using UnityEngine;
using UnityEngine.UI;

public class ImagePanelController
{
    private readonly RectTransform _transformPanel;
    private readonly GridLayoutGroup _layoutGroup;
    private readonly int _uIElementCount;

    public ImagePanelController(RectTransform transformPanel, GridLayoutGroup gridLayoutGroup, int uIElementCount)
    {
        _transformPanel = transformPanel;
        _layoutGroup = gridLayoutGroup;
        _uIElementCount = uIElementCount;
    }

    public void DrawPanel()
    {
        float heigth = _layoutGroup.cellSize.y * 1.1f;
        float width = (_layoutGroup.cellSize.x * _uIElementCount 
            + _layoutGroup.spacing.x * (_uIElementCount - 1)) * 1.05f;

        _transformPanel.sizeDelta = new Vector2(width, heigth);
    }

    public static void DrawPanelWhthParameters(GridLayoutGroup panelGridLayoutGroup, 
        GridLayoutGroup arrayPanelsGridLayoutGroup, int uIElementCount)
    {
        float heigth = panelGridLayoutGroup.cellSize.y * 1.1f;
        float width = (panelGridLayoutGroup.cellSize.x * uIElementCount
            + panelGridLayoutGroup.spacing.x * (uIElementCount - 1)) * 1.05f;

        arrayPanelsGridLayoutGroup.cellSize = new Vector2(width, heigth);
    }
}
