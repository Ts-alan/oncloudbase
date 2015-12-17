function printTable (tableId)
{
    $(tableId).printThis();
}

function printPicture(picture) {
  
    picture += '.active';
    $(picture).append("<div id='target'></div>");
    $(picture).clone().appendTo('#target');
    $('#target').printThis();
    $('#target').remove();

}