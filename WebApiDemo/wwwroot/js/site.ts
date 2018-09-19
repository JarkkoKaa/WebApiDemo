const result: any = <HTMLParagraphElement> document.getElementById('result'); 
fetch('http://localhost:9080/api/books')
    .then(function (response) {
        return response.json();
    })
    .then(function (resultJSON) {
        //console.log(JSON.stringify(resultJSON));
        setData(resultJSON);
    });
function setData(resultJSON: any) {
    result.innerHTML = resultJSON;
}
