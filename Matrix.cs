using System;
using System.Data;

namespace G__Marching_Sqaure
{
    public class Matrix<T>  //: IComparable
    {
        private T[,] __array2d;
        public int Height { get; set; }
        public int Width { get; set; }
        public bool IsEmpty
        {
            get
            {
                if (__array2d == null) return true;
                else return false;
            }
        }

        public Matrix() { }
        public Matrix(T[,] data)
        {
            this.Set(data);
        }

        public Matrix(int rows, int cols)
        {
            Height = rows;
            Width = cols;
            __array2d = new T[Height, Width];
        }
        public T Get(int x, int y)
        {
            if (__array2d == null)
            {
                throw new Exception("array is empty");
            }
            if (x < Height && y < Width)
            {
                if (__array2d != null)
                {
                    return __array2d[x, y];
                }
                else
                {
                    throw new Exception("array is null");
                }
            }
            else
            {
                string message = string.Empty;

                if (x >= Height) message = "x-value exceeds Width ";
                if (y >= Width) message += "y-value exceeds Height ";
                message += "in Array2d.Get(x,y).";
                throw new Exception(message);
            }
        }

        public void Set(int x, int y, T val)
        {
            if (__array2d == null)
            {
                __array2d = new T[Height, Width];
            }
            else
            {
                if (Height != __array2d.GetLength(0))
                {
                    __array2d = null;
                    __array2d = new T[Height, Width];
                }
            }

            if (x < Height && y < Width)
            {
                __array2d[x, y] = val;
            }
            else
            {

                throw new Exception(x + ", " + Height + "," + y + "," + Width);
            }
        }

        public T[,] Get()
        {
            return __array2d;
        }

        public T[] To1d()
        {
            T[] array1d = new T[Height * Width];

            int i = 0;
            for (int x = 0; x < Height; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    array1d[i++] = __array2d[x, y];
                }
            }

            return array1d;
        }

        public T this[int x, int y]
        {
            get
            {
                return Get(x, y);
            }
            set
            {
                Set(x, y, value);
            }
        }

        public void Set(T[,] arr)
        {
            if (arr != null)
            {
                int rows = arr.GetLength(0);
                int cols = arr.GetLength(1);

                __array2d = arr;
                Height = rows;
                Width = cols;
            }
            else
            {
                throw new Exception("array is null");
            }
        }

        public Matrix<T> Copy()
        {
            Matrix<T> copy = new Matrix<T>();

            copy.Set(this.Get());

            return copy;
        }

        public static Matrix<T> From2d(T[,] data)
        {
            Matrix<T> array2d = new Matrix<T>();
            array2d.Set(data);

            return array2d;
        }

        public void Fill(T color)
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    this.Set(i, j, color);
                }
            }
        }

        public void Tile(int xFactor, int yFactor)
        {
            Matrix<T> dest = new Matrix<T>(Height * xFactor, Width * yFactor);

            for (int x = 0; x < this.Height; x++)
            {
                for (int y = 0; y < this.Width; y++)
                {
                    T val = this.Get(x, y);

                    for (int i = 0; i < xFactor; i++)
                    {
                        for (int j = 0; j < yFactor; j++)
                        {
                            dest.Set(i * this.Height + x, j * this.Width + y, val);
                        }
                    }
                }
            }

            this.Set(dest.Get());
        }

        #region ToDataTable
        public DataTable ToDataSet()
        {
            DataTable dt = new DataTable();

            for (int i = 0; i < Width; i++)
            {
                dt.Columns.Add("Column" + (i + 1));
            }

            for (var i = 0; i < Height; ++i)
            {
                DataRow row = dt.NewRow();
                for (var j = 0; j < Width; ++j)
                {
                    row[j] = this.Get(i, j);
                }
                dt.Rows.Add(row);
            }

            return dt;
        }
        #endregion

        #region Crop
        public void CropBy(int horizCropSize, int vertCropSize)
        {
            CropBy(horizCropSize, horizCropSize, vertCropSize, vertCropSize);
        }

        public void CropBy(int left, int right, int top, int bottom)
        {
            int width = this.Height;
            int height = this.Width;

            CropRect(left, top, width - (left + right), height - (top + bottom));
        }

        private void CropRect(int leftX, int topY, int width, int height)
        {
            int newWidth = width;
            int newHeight = height;

            Matrix<T> cropped = new Matrix<T>(newWidth, newHeight);


            for (int x = 0; x < newWidth; x++)
            {
                for (int y = 0; y < newHeight; y++)
                {
                    int pX = x + leftX;
                    int pY = y + topY;

                    cropped.Set(x, y, this.Get(pX, pY));
                }
            }

            this.Set(cropped.Get());
        }
        #endregion

        #region Pad
        public void PadTo(int newWidth, int newHeight)
        {
            int horiz = Math.Abs(newWidth - Height);
            int vert = Math.Abs(newHeight - Width);

            int horizPadSize = horiz / 2;
            int vertPadSize = vert / 2;

            PadBy(horizPadSize, vertPadSize);

            // fix the division loss
            if (this.Height != newWidth)
            {
                int diff = Math.Abs(this.Height - newWidth);

                this.PadBy(0, diff, 0, 0);
            }

            if (this.Width != newHeight)
            {
                int diff = Math.Abs(this.Width - newHeight);

                this.PadBy(0, 0, 0, diff);
            }
        }

        public void PadBy(int horizPadSize, int vertPadSize)
        {
            PadBy(horizPadSize, horizPadSize, vertPadSize, vertPadSize);
        }

        public void PadBy(int leftPadSize, int rightPadSize, int topPadSize, int bottompadSize)
        {
            int imageWidth = Height;
            int imageHeight = Width;

            int newWidth = imageWidth + (leftPadSize + rightPadSize);
            int newHeight = imageHeight + (topPadSize + bottompadSize);
            /*
             It is always guaranteed that,
                 
                    width < newWidth
                 
                        and
                  
                    height < newHeight                  
             */
            if ((imageWidth < newWidth && imageHeight < newHeight)
                    || (imageWidth < newWidth && imageHeight == newHeight)
                    || (imageWidth == newWidth && imageHeight < newHeight))
            {
                Matrix<T> paddedImage = new Matrix<T>(newWidth, newHeight);

                T color = default(T);

                paddedImage.Fill(color);

                int startPointX = leftPadSize;
                int startPointY = topPadSize;


                for (int x = startPointX; x < startPointX + imageWidth; x++)
                {
                    for (int y = startPointY; y < startPointY + imageHeight; y++)
                    {
                        int xxx = x - startPointX;
                        int yyy = y - startPointY;

                        paddedImage.Set(x, y, this.Get(xxx, yyy));
                    }
                }

                this.Set(paddedImage.Get());
            }
            else if (imageWidth == newWidth && imageHeight == newHeight)
            {
                //do nothing
            }
            else
            {
                throw new Exception("Pad() -- threw an exception");
            }
        }
        #endregion

        #region Pad replicate
        public void PadReplicateTo(int newWidth, int newHeight)
        {
            if (Height >= newWidth && Width >= newHeight)
            {
                //do nothing
            }

            int padWidth = (newWidth - Height) / 2;
            int padHeight = (newHeight - Width) / 2;

            PadReplicateBy(padWidth, padWidth, padHeight, padHeight);
        }

        public void PadReplicateBy(int size)
        {
            PadReplicateBy(size, size, size, size);
        }

        public void PadReplicateBy(int horizontal, int vertical)
        {
            PadReplicateBy(horizontal, horizontal, vertical, vertical);
        }

        public void PadReplicateBy(int left, int right, int top, int bottom)
        {
            int newWidth = Height + left + right;
            int newHeight = Width + top + bottom;

            Matrix<T> newImage = new Matrix<T>(newWidth, newHeight);


            for (int x = 0; x < newWidth; x++)
            {
                for (int y = 0; y < newHeight; y++)
                {
                    int oldX = 0;
                    int oldY = 0;

                    if (x < left)
                    {
                        oldX = 0;
                    }

                    if (x > left && x < left + Height)
                    {
                        oldX = x - left;
                    }

                    if (x >= left + Height)
                    {
                        oldX = Height - 1;
                    }

                    if (y < top)
                    {
                        oldY = 0;
                    }

                    if (y > top && y < top + Width)
                    {
                        oldY = y - top;
                    }

                    if (y >= top + Width)
                    {
                        oldY = Width - 1;
                    }

                    newImage[x, y] = this.Get(oldX, oldY);
                }
            }

            this.Set(newImage.Get());
        }
        #endregion

        #region Pad border wrap
        public void PadBorderWrapBy(int left, int right, int top, int bottom)
        {
            double l = left;
            double r = right;
            double t = top;
            double b = bottom;
            double w = Height;
            double h = Width;

            int leftFactor = (int)Math.Ceiling(l / w);
            int rightFactor = (int)Math.Ceiling(r / w);
            int topfactor = (int)Math.Ceiling(t / h);
            int bottomfactor = (int)Math.Ceiling(b / h);

            Matrix<T> dest = new Matrix<T>(this.Get());
            dest.Tile(leftFactor + rightFactor + 1, topfactor + bottomfactor + 1);

            int leftCrop = Math.Abs(leftFactor * Height - left);
            int rightCrop = Math.Abs(rightFactor * Height - right);
            int topCrop = Math.Abs(topfactor * Width - top);
            int bottomCrop = Math.Abs(bottomfactor * Width - bottom);

            dest.CropBy(leftCrop, rightCrop, topCrop, bottomCrop);

            this.Set(dest.Get());
        }
        #endregion

        

        public void Clear()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    this[i, j] = default(T);
                }
            }
        }

        #region IDisposable implementation
        ~Matrix()
        {
            this.Dispose(false);
        }

        protected bool Disposed { get; private set; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {
                    // Perform managed cleanup here.
                    //IDisposable disp = (IDisposable)_2dArray;

                    __array2d = null;
                }

                // Perform unmanaged cleanup here.
                Height = 0;
                Width = 0;

                this.Disposed = true;
            }
        }
        #endregion
    }
}