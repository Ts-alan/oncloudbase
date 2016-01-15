function printTable (tableId, hId)
{
    $(document.body).append("<div id='target'></div>");
    $("#CityStreet").clone().appendTo('#target');
    $(hId).clone().appendTo('#target');
    $(tableId).clone().appendTo('#target');
    $("#target").find("table.ui-jqgrid-htable").unwrap().unwrap().css({
        "border-width": "1px",
        "border-style": "solid"
    });
    $("#target").find("td").css({
        "border-width": "1px",
        "border-style": "solid",
        "padding-left": "5px"
    });
    $('#target').printThis();
    $('#target').remove();
}

function printPicture(picture) {
  
    picture += '.active';
    $(picture).append("<div id='target'></div>");
    $(picture).clone().appendTo('#target');
    $('#target').printThis();
    $('#target').remove();

}