namespace ImgUp
{
    static class Variables
    {
        public const int MEMO_MAX = 10;
        public const int NULL_LOCATION = int.MaxValue;

        private static readonly object[] syncLock = new object[MEMO_MAX];
        private static MemoForm[] memoForms = new MemoForm[MEMO_MAX];
        private static System.Drawing.Point[] memoLocations = new System.Drawing.Point[MEMO_MAX];
        
        public static void init()
        {
            for(int i = 0; i < MEMO_MAX; i++)
            {
                syncLock[i] = new object();
                memoForms[i] = new MemoForm(i);
                memoLocations[i] = new System.Drawing.Point(NULL_LOCATION, NULL_LOCATION);
            }   
        }

        public static MemoForm GetMemo(int index)
        {
            lock (syncLock[index])
            {
                if(memoForms[index].IsDisposed) memoForms[index] = new MemoForm(index);
                return memoForms[index];
            }
        }

        public static void SetLocation(int index, System.Drawing.Point point)
        {
            lock (syncLock[index])
            {
                memoLocations[index] = point;
            }
        }

        public static System.Drawing.Point GetLocation(int index)
        {
            lock (syncLock[index])
            {
                return memoLocations[index];
            }
        }
    }
}

