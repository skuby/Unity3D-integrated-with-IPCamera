#pragma strict

// http://docs.unity3d.com/Documentation/ScriptReference/WWW.LoadImageIntoTexture.html

var url = "rtsp://192.168.1.10/media/video1";

function Start () {
    // Create a texture in DXT1 format

    // NOTE: you may want to experiment with different texture formats, specially in a web context
    // https://docs.unity3d.com/Documentation/ScriptReference/TextureFormat.html
    renderer.material.mainTexture = new Texture2D(4, 4, TextureFormat.DXT1, false); 
    Debug.Log(address);
    Debug.Log(url);
    while(true) {
        // Start a download of the given URL
        var www = new WWW(url);
        // wait until the download is done
        yield www;
        // assign the downloaded image to the main texture of the object
        www.LoadImageIntoTexture(renderer.material.mainTexture);
    }
}