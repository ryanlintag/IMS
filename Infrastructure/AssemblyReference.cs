﻿using System.Reflection;

namespace Infrastructure
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
        private static void Reference()
        {
            var assembly = Application.AssemblyReference.Assembly;
        }
    }
}