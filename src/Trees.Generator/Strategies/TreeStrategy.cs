using Common.Interfaces;

namespace Trees.Generator.Strategies;

public abstract class TreeStrategy(IOrganizationComposite composite)
{
  protected List<IOrganizationComposite> _previous_depth_nodes = [];
  protected List<IOrganizationComposite> _current_depth_nodes = [composite];

  public abstract Task StoreAsync(string name, int parnetId);

  public virtual void DecreaseNodesWidth(int maxWidth, int start, int end)
  {
    if (_previous_depth_nodes.Count > maxWidth)
      _previous_depth_nodes = _current_depth_nodes.GetRange(start, end);
    else
      _previous_depth_nodes = [.. _current_depth_nodes];

    _current_depth_nodes = [];
  }

  public int PreviousNodesCount => _previous_depth_nodes.Count;
}