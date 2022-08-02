using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelData : MonoBehaviour
{
    int[,] data = new int[,] { { 0, 1, 1 }, { 1, 1, 1 }, { 1, 1, 0 } };
    public int Width
    {
        get { return data.GetLength(0); }
    }

    public int Depth
    {
        get { return data.GetLength(1); }
    }

    public int GetCell(int x, int z)
    {
        return data[x,z];
    }
    public int GetNeighbor(int x, int z, Direction dir)
    {
        DataCoordinate offsetToCheck = offsets[(int)dir];
        DataCoordinate neighborCoor = new DataCoordinate(x + offsetToCheck.x, 0 + offsetToCheck.y, z + offsetToCheck.z);

        if (neighborCoor.x<0 || neighborCoor.x >= Width || neighborCoor.y != 0|| neighborCoor.z >= Depth|| neighborCoor.z <0)
        {
            return 0;
        }
        else
        {
            return GetCell(neighborCoor.x, neighborCoor.z);
        }

    }
    struct DataCoordinate
    {
        public int x;
        public int y;
        public int z;

        public DataCoordinate(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;

        }
    }
    DataCoordinate[] offsets ={
        new DataCoordinate(0,0,1),//North
        new DataCoordinate(1,0,0),
        new DataCoordinate(0,0,-1),
        new DataCoordinate(-1,0,0),
        new DataCoordinate(0,1,0),
        new DataCoordinate(0,-1,0)
    };

}
public enum Direction
{
North,
East,
South,
West,
Up,
Down
}