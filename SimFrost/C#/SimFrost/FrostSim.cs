using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SimFrost
{
    public class FrostSim
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public void GenerateGrid(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }

    public class Cell
    {
        public string Status { get; set; }
        public Cell()
        {
            Status = "v";
        }
    }

    [TestFixture]
    public class FrostSimTests
    {
        [Test]
        public void GenerateGridSetsHeight()
        {
            var sim = new FrostSim();
            sim.GenerateGrid(10, 6);
            Assert.AreEqual(10, sim.Height);
        }
        [Test]
        public void GenerateGridSetsWidth()
        {
            var sim = new FrostSim();
            sim.GenerateGrid(10, 6);
            Assert.AreEqual(6, sim.Width);
        }

    }

    [TestFixture]
    public class CellTests
    {
        [Test]
        public void CellsHaveAStatus()
        {
            var cell = new Cell();
            Assert.AreEqual("v", cell.Status);
        }
    }

    [TestFixture]
    public class NeighbourHoodTests
    {
        [Test]
        public void NeighbourhoodsContainFourCells()
        {
            var cell = new Cell();
            var neighbourhood = new Neighbourhood(cell, cell, cell, cell);
            Assert.AreEqual(4, neighbourhood.Cells.Count);
        }
        [Test]
        public void NeighbourhoodsContainFourCellsInAGrid()
        {
            var cell = new Cell();
            var neighbourhood = new Neighbourhood(cell, cell, cell, cell);
        }
    }

    public class Neighbourhood
    {
        public List<Cell> Cells;

        public Neighbourhood(Cell cell, Cell cell1, Cell cell2, Cell cell3)
        {
            Cells = new List<Cell> {cell, cell1, cell2, cell3};
        }
    }
}
