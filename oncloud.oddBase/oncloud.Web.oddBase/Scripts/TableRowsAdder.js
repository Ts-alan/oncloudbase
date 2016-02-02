$(document).ready(function() {
    //подсказки разметки
    var autocompleteUrlRM = '/Home/FindRoadMarking';
    $(' form').on('keydown.autocomplete', ".FindRoadMarking", function () {
        $(this).autocomplete({
            source: autocompleteUrlRM,
            minLength: 1,
            select: function (event, ui) {
                $.get('/Home/GetRoadMarking', {
                    idRM: ui.item.value
                }).success(function (result) {
                    var JsonObject = JSON.parse(result);


                    $(event.target).closest("tr").children("td").eq(1).html('<img style="height: 150px; width: 150px" src="/HorizontalRoadMarkings/GetImage/' + JsonObject[0].id + '">'); $(event.target).closest("tr").children("td").eq(2).text(JsonObject[0].description);
                    $(event.target).closest("tr").children("td").eq(3).html('<input type="number"   name="ModalsL' + ui.item.value + '" type="text"/>');
                    $(event.target).closest("tr").children("td").eq(4).html('<input type="number"   name="ModalsA' + ui.item.value + '" type="text"/>');
                    $(event.target).closest("tbody").append('<tr>' +
                           '<td style="width: 185px;height: 115px"><input type="text" class="FindRoadMarking"></td>' +
                           '<td style="width: 115px;height: 115px"></td>' +
                           '<td style="width: 117px"></td>' +
                           '<td style="width: 115px; vertical-align: middle"></td>' +
                           '<td style="vertical-align: middle"></td>' +
                           '<td><a href="#">Удалить строку</a></td>' +
                           '</tr>');
                });
            }
        });
    });
    //подсказки ограждений
    var autocompleteUrlRB = '/Home/FindRoadBarriers';
    $(' form').on('keydown.autocomplete', ".FindRoadBarriers", function () {
        $(this).autocomplete({
            source: autocompleteUrlRB,
            minLength: 1,
            select: function (event, ui) {
                $.get('/Home/GetRoadBarriers', {
                    idRB: ui.item.value
                }).success(function (result) {
                    var JsonObject = JSON.parse(result);

                    var url = '/RoadBarriers/GetImage/' + JsonObject[0].Id;
                    //console.log(JsonObject);
                    function IsValidImageUrl(url) {
                        $("<img>", {
                            src: url,
                            error: function () {
                                //alert(url + ': ' + false);
                            },
                            load: function () {
                                $("#AddSrc" + JsonObject[0].Id).attr("src", "/RoadBarriers/GetImage/" + JsonObject[0].Id);
                                $("#AddSrc" + JsonObject[0].Id).css({ "height": "150px", "width": "150px" });
                            }
                        });
                    }

                    //$(event.target).closest("tr").children("td").eq(1).html('<img style="height: 150px; width: 150px" src="/RoadBarriers/GetImage/' + JsonObject[0].Id + '">');
                    $(event.target).closest("tr").children("td").eq(1).html('<img id="AddSrc' + JsonObject[0].Id + '">');
                    IsValidImageUrl(url);
                    $(event.target).closest("tr").children("td").eq(2).text(JsonObject[0].Description);
                    $(event.target).closest("tr").children("td").eq(3).html('<input type="number"   name="1RoadBarriers' + ui.item.value + '" type="text"/>');
                    //$(event.target).closest("tr").children("td").eq(4).html('<input type="number"   name="ModalsA' + ui.item.value + '" type="text"/>');
                    $(event.target).closest("tbody").append('<tr>' +
                           '<td style="width: 145px;height: 115px"><input type="text" class="FindRoadBarriers"></td>' +
                           '<td style="width: 115px;height: 115px"></td>' +
                           '<td style="width: 117px"></td>' +
                           '<td style="vertical-align: middle">' +

                           '</td>' +
                           '<td><a href="#">Удалить строку</a></td>' +
                           '</tr>');
                });
            }
        });
    });
    //подсказки знаков
    var autocompleteUrlRS = '/Home/FindRoadSings';
    $('form').on('keydown.autocomplete', ".FindRoadSings", function () {
        $(this).autocomplete({
            source: autocompleteUrlRS,
            minLength: 1,
            select: function (event, ui) {
                $(event.target).closest("tr").children("td").eq(2).attr("");
                $.get('/Home/GetRoadSigns', {
                    idRS: ui.item.value
                }).success(function (result) {
                    function compare(a, b) {
                        if (a.ItemOrder < b.ItemOrder)
                            return -1;
                        else if (a.ItemOrder > b.ItemOrder)
                            return 1;
                        else
                            return 0;
                    }

                    var JsonObject = JSON.parse(result);
                    JsonObject[0].RoadSignItems.sort(compare);

                    $(event.target).closest("tr").children("td").eq(1).html('<img style="height: 100px; width: 100px" src="/RoadSigns/GetImage/' + JsonObject[0].id + '">');
                    $(event.target).closest("tr").children("td").eq(2).text(JsonObject[0].Description);
                    $(event.target).closest("tr").children("td").eq(3).children().remove();
                    if (JsonObject[0].RoadSignItems.length == 0) {
                        $(event.target).closest("tr").children("td").eq(4).html('<input type="number"   name="1ModalC' + ui.item.value + '" type="text"/>');
                    }

                    if (JsonObject[0].RoadSignItems.length > 0) {
                        if (JsonObject[0].RoadSignItems[0].ImageData != null) {
                            $(event.target).closest("tr").children("td").eq(4).html('<input type="number"  name="1ModalC' + ui.item.value + 'I1" type="text"/>');
                            var dd = '<select  class="dd">';
                            dd += '<option selected ">Выбирите маркер</option>';
                            for (var i = 0; i < JsonObject[0].RoadSignItems.length; i++) {
                                dd += '<option value="' + JsonObject[0].RoadSignItems[i].ItemOrder + '" data-image="/RoadSigns/GetItemImage/' + JsonObject[0].RoadSignItems[i].Id + '?hallmark=' + JsonObject[0].RoadSignItems[i].Hallmark + '"></option>';

                            }
                            dd += '</select>';

                            $(event.target).closest("tr").children("td").eq(3).html(dd);

                            $(event.target).closest("tr").children("td").eq(3).children().msDropDown();
                        } else {
                            $(event.target).closest("tr").children("td").eq(4).html('<input type="number"  name="1ModalC' + ui.item.value + 'I1" type="text"/>');
                            var dd = '<select  class="dd">';

                            for (var i = 0; i < JsonObject[0].RoadSignItems.length; i++) {
                                dd += '<option  value="' + JsonObject[0].RoadSignItems[i].ItemOrder + '">' + JsonObject[0].RoadSignItems[i].Description + '</option>';

                            }
                            dd += '</select>';

                            $(event.target).closest("tr").children("td").eq(3).html(dd);
                        }
                        $(event.target).closest("tr").find("select").change(function () {
                            $(event.target).closest("tr").children("td").eq(4).html('<input   name="1ModalC' + ui.item.value + 'I' + $(this).val() + '" type="text"/>');

                        });
                    }
                    $(event.target).closest("tbody").append('<tr>' +
                        '<td style="width: 185px;height: 115px"><input type="text" class="FindRoadSings"></td>' +
                        '<td style="width: 115px;height: 115px"></td>' +
                        '<td style="width: 117px"></td>' +
                        '<td style="width: 115px"></td>' +
                        '<td style="vertical-align: middle"></td>' +
                        '<td><a href="#">Удалить строку</a></td>' +
                        '</tr>');
                    $(event.target).closest("tbody").children("tr").last().children("td").last().children("a").click(function (e) {
                        $(e.currentTarget).closest("tr").remove();
                    });
                });
            }
        });
    });
    }
)


