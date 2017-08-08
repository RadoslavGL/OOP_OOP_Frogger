using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frogger.Renderer;

namespace Frogger
{
    public class Program
    {
        static void Main(string[] args)
        {
            Renderer.Renderer.InitializeRenderer();
            Renderer.Renderer.Execute();
            
        }
    }
}
/*
 * upgrades:
 * може да се сложи IDRow да е някъв enum, но не виждам особено голям смисъл, нито ще ги викам по него, нито ще ги сортирам нито нищо
 * 
 */