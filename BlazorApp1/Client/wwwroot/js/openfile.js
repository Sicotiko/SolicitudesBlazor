function BlazorDownloadFile(filename, content) {
    // thanks to Geral Barre : https://www.meziantou.net/generating-and-downloading-a-file-in-a-blazor-webassembly-application.htm 

    // Create the URL
    const file = new File([content], filename, { type: "application/octet-stream" });
    const exportUrl = URL.createObjectURL(file);

    // Create the <a> element and click on it
    const a = document.createElement("a");
    document.body.appendChild(a);
    a.href = exportUrl;
    a.download = filename;
    a.target = "_self";
    a.click();

    // We don't need to keep the object url, let's release the memory
    // On Safari it seems you need to comment this line... (please let me know if you know why)
    //URL.revokeObjectURL(exportUrl);
}

function BlazorOpenFile(filename, content) {

    // Create the <a> element and click on it
    const a = document.createElement("a");
    document.body.appendChild(a);
    a.href = filename;
    a.download = filename;
    a.target = "_self";
    a.click();
}

window.saveAsFile = function (fileName, byteBase64) {
    var link = this.document.createElement('a');
    link.download = fileName;
    link.href = "data:application/octet-stream;base64," + byteBase64;
    this.document.body.appendChild(link);
    link.click();
    this.document.body.removeChild(link);
}