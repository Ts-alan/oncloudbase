function printTable (tableId, hId)
{
    $(tableId).append("<div id='target'></div>");
    $(hId).clone().appendTo('#target');
    $(tableId).clone().appendTo('#target');
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