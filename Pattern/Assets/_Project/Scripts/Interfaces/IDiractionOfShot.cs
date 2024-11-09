using System.Collections.Generic;
using UnityEngine;

public interface IDiractionOfShot
{
    public List<Vector3> Durations { get; }
    public List<float> KickBackScale { get; }
}
