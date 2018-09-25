fetch('http://localhost:9080/api/books')
    .then(function (response) {
    return response.json();
})
    .then(function (resultJSON) {
    setData(resultJSON);
});
function setData(resultJSON) {
    var table = document.getElementById('resultTable');
    resultJSON.forEach(function (element) {
        var row = table.insertRow();
        var cellID = row.insertCell(0);
        var cellName = row.insertCell(1);
        var cellAuthor = row.insertCell(2);
        var cellYear = row.insertCell(3);
        cellID.innerHTML = element.id;
        cellName.innerHTML = element.name;
        cellAuthor.innerHTML = element.author;
        cellYear.innerHTML = element.releaseYear;
    });
}
//# sourceMappingURL=site.js.map