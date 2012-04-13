﻿namespace SuperNet.Framework.Interface
{
    public interface IEdge
    {
        IVertex From { get; }
        IVertex To { get; }
        int Weight { get; }
    }
}