namespace ImgUp
{
    static class Variables
    {
        public const int MEMO_MAX = 10;

        private static readonly object[] syncLock = new object[MEMO_MAX];
        public static MemoForm[] memoForms = new MemoForm[MEMO_MAX];
        
        public static void init()
        {
            for(int i = 0; i < MEMO_MAX; i++)
            {
                syncLock[i] = new object();
                memoForms[i] = new MemoForm(i);
            }   
        }

        public static MemoForm GetMemo(int index)
        {
            lock(syncLock[index])
            {
                return memoForms[index];
            }
        }
    }
}

