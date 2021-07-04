# ImgUp  
##### Image Memo Window Application  
> Target Framework : .NET Framework 4.6.1  
  
![ImgUp](https://user-images.githubusercontent.com/47464230/124309200-5362c200-dba5-11eb-98fc-b1681c4b291f.gif)  
  
## Functions  
+ Load image from Clipboard and show up. (Memo hotkey : Alt + Shift + 0 ~ 9)   
: You can capture images with Hotkey (Window key + Shift + S). Then image is saved in Clipboard.  
: If Nth memo is already shown, overwriting image.  
: If Nth memo is Hided, It reshow that memo without overwriting image.  
  
+ Load saved images and locations. Then images show up when application runs.  
: Load memo_0 ~ 9.png and imgup.bin at application startup path. It load images only that locations are saved.
  
+ Save the image and location of memo.  
: Images are saved with PNG(memo_0 ~ 9.png) format and loactions saved with BIN(imgup.bin) format at application startup path.  
  
+ Set opacity of images.  
: Decrease opacity of images. Minimum opacity is 10%. (Decrease opacity hotkey : Q)  
: Increase opacity of images. Maximum opacity is 100%. (Increase opacity hotkey : W)  
  
+ Bring to front all memos. (AllToFront hotkey : Alt + Shift + S)  
: Bring all memo windows to front. But if memo is hided, it is ignored.  

+ Memo Options  
![memo_option](https://user-images.githubusercontent.com/47464230/124386350-f1c16580-dd14-11eb-831e-e39be7922629.png)  
  `TopMost` Set memo window topmost.  
  `Minimize` Set memo window minimized.  
  `Save image` Save only the image without location.  
  `Copy` Copy image to clipboard.  
  `Hide`  Hide memo. It is reshown with memo hotkey. Also it is not shown with AllToFront hotkey.  
  `Erase`  Dispose memo resources.  
  
## Development Issues  
#### 1. Flickering when resizing images.  
When I tried to resize the memo forms, BackgroundImage was flickering.  
It happened when drawing graphics with single buffering. The flickering occured when I resized forms because the data of the next picture cannot be transferred while data is being saved.  
So it is solved with DoubleBuffered property to true.  
``` C#
this.DoubleBuffered = true;
```  
  
#### 2. Move and resize the form when its FormBorderStyle property is None  
I tried to set memo forms' FormBorderStyle property None. But this way, I could not control Forms such as Resize, Move and MouseClick.  
I solved it with overriding WndProc method. You can handle windows' message with WndProc method.  
Details are below.  
> WM_NCHITTEST : https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest  
> WM_NCRBUTTONDOWN : https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncrbuttondown  
> WM_KEYDOWN : https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-keydown  
  
``` C#
private const int WM_NCHITTEST = 0x0084;
private const int WM_NCRBUTTONDOWN = 0x00A4;
private const int WM_KEYDOWN = 0x0100;
...
protected override void WndProc(ref Message m)
{
    base.WndProc(ref m);
            
    if(m.Msg == WM_NCRBUTTONDOWN)
    {
        if(!memoForm_Cms.Visible) memoForm_Cms.Show(Cursor.Position);
    }

    if(m.Msg == WM_KEYDOWN)
    {
        if ((Keys)m.WParam == Keys.Q)
        {
            setOpacity(-opacityChange);
        }
        else if ((Keys)m.WParam == Keys.W)
        {
            setOpacity(opacityChange);
        }
    }
            
    if (m.Msg == WM_NCHITTEST) 
    {
        if (m.Result == HTCLIENT)
        {
            Point screenPoint = new Point(m.LParam.ToInt32());
            Point clientPoint = this.PointToClient(screenPoint);

            if (clientPoint.X >= this.Size.Width - RESIZE_HANDLE_SIZE && clientPoint.Y >= this.Size.Height - RESIZE_HANDLE_SIZE)
            {
                m.Result = HTBOTTOMRIGHT;
            }
            else
            {
                m.Result = HTCAPTION;
            }
        }
    }  
}
```
  
#### 3. ShowBalloonTip() not working.  
My computer with Windows 10, ShowBalloonTip() is not working.  
It is solved with Windows 10 Setting.  
Settings > System > Notifications & actions, and turn on "Get notifications from apps and other senders"  
