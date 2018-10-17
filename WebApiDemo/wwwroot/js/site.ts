fetch('http://localhost:9080/api/books')
    .then(function (response) {
        return response.json();
    })
    .then(function (resultJSON) {
        setData(resultJSON);
    });
function setData(resultJSON: any) {
    let table = <HTMLTableElement>document.getElementById('resultTable');
    resultJSON.forEach(function (element: any) {
        let row = table.insertRow();
        let cellID = <HTMLTableCellElement> row.insertCell(0);
        let cellName = <HTMLTableCellElement>row.insertCell(1);
        let cellAuthor = <HTMLTableCellElement>row.insertCell(2);
        let cellYear = <HTMLTableCellElement>row.insertCell(3);

        cellID.innerHTML = element.id;
        cellName.innerHTML = element.name;
        cellAuthor.innerHTML = element.author;
        cellYear.innerHTML = element.releaseYear;   
    });
}
