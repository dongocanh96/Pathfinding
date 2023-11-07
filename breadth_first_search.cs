public List<int> FindPath(int originTileSerial, int targetTileSerial)
        {
            List<int> closetPath = new List<int>();
            Queue<int[]> openSet = new Queue<int[]>();
            openSet.Enqueue(new int[] { originTileSerial });
            List <int> explored = new List<int>();
            if (originTileSerial == targetTileSerial)
            {
                Debug.Log("Same Node");
                closetPath.Add(originTileSerial);
                return closetPath;
            }

            while (openSet.Count > 0)
            {
                int[] path = openSet.Dequeue();
                int currentTileSerial = path.AsQueryable().Last();
                if (!explored.Contains(currentTileSerial))
                {
                    foreach (int adjacentTileSerial in FindAdjacentTilesSerial(currentTileSerial, targetTileSerial))
                    {
                        List<int> new_path_serial = path.ToList();
                        new_path_serial.Add(adjacentTileSerial);
                        int[] new_path = new_path_serial.ToArray();
                        openSet.Enqueue(new_path);
                        if (adjacentTileSerial == targetTileSerial)
                        {
                            closetPath = new_path.ToList();
                            return closetPath;
                        }
                    }
                    explored.Add(currentTileSerial);
                }                
            }
            Debug.Log("Khong tim thay duong");
            return closetPath;
        }

        private List<int> FindAdjacentTilesSerial(int origin, int target)
        {
            List<int> result = new List<int>();
            if (!topCorner.Contains(origin))
            {
                int adjacenTileSerialToAdd = origin - maxTilesPerRow;
                if(adjacenTileSerialToAdd != target)
                {
                    floorState state = floorTiles[adjacenTileSerialToAdd].gameObject.GetComponent<MoverGame_FloorTile>().GetFloorState();
                    if (state == floorState.FREE)
                    {
                        result.Add(adjacenTileSerialToAdd);
                    }
                }
                else
                {
                    result.Add(adjacenTileSerialToAdd);
                }
            }

            if (!bottomCorner.Contains(origin))
            {
                int adjacenTileSerialToAdd = origin + maxTilesPerRow;
                if (adjacenTileSerialToAdd != target)
                {
                    floorState state = floorTiles[adjacenTileSerialToAdd].gameObject.GetComponent<MoverGame_FloorTile>().GetFloorState();
                    if (state == floorState.FREE)
                    {
                        result.Add(adjacenTileSerialToAdd);
                    }
                }
                else
                {
                    result.Add(adjacenTileSerialToAdd);
                }
                
            }

            if(!rightCorner.Contains(origin))
            {
                int adjacenTileSerialToAdd = origin + 1;
                if(adjacenTileSerialToAdd != target)
                {
                    floorState state = floorTiles[adjacenTileSerialToAdd].gameObject.GetComponent<MoverGame_FloorTile>().GetFloorState();
                    if (state == floorState.FREE)
                    {
                        result.Add(adjacenTileSerialToAdd);
                    }
                }
                else
                {
                    result.Add(adjacenTileSerialToAdd);
                }                
            }

            if (!leftCorner.Contains(origin))
            {
                int adjacenTileSerialToAdd = origin - 1;
                if (adjacenTileSerialToAdd != target)
                {
                    floorState state = floorTiles[adjacenTileSerialToAdd].gameObject.GetComponent<MoverGame_FloorTile>().GetFloorState();
                    if (state == floorState.FREE)
                    {
                        result.Add(adjacenTileSerialToAdd);
                    }
                }
                else
                {
                    result.Add(adjacenTileSerialToAdd);
                }
            }

            return result;
        }