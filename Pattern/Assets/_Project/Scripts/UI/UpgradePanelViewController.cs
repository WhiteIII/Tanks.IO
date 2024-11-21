using UnityEngine;

public class UpgradePanelViewController
{ 
    private readonly UIElementRepository _elementRepository;
    private readonly UpgradePanelView _view = new();

    public UpgradePanelViewController(UIElementRepository elementRepository)
    {
        _elementRepository = elementRepository;

        _elementRepository.OffAllObjects();
    }

    public void DrawNewState()
    {
        if (_elementRepository.IsNotEmpty == false)
            return;
        
        GameObject uIElement = _elementRepository.GetAndUnregister();
        _view.DrawNewState(uIElement);
    }
}