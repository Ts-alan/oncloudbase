    //чистка полей
    function cleaningRoadSigns(par) {

        $("#ModalRoadSigns" + par + " tr:gt(1)").each(function (indx, element) {
            $(element).remove();
        });
        $("#ModalRoadSigns" + par + " tr:eq(1)")
            .children().eq(0).children().val("");
        $("#ModalRoadSigns" + par + " tr:eq(1)")
            .children().eq(1).children().remove();
        $("#ModalRoadSigns" + par + " tr:eq(1)")
            .children().eq(2).html("");
        $("#ModalRoadSigns" + par + " tr:eq(1)")
            .children().eq(3).children().remove();
        $('[data-target="#ModalRoadSigns' + par + '"]').removeClass("btn-danger");
        $('[data-target="#ModalRoadSigns' + par + '"]').addClass("btn-default");
    }

    function cleaningModalMackUp(par) {
        var mkp = '<td style="width: 100px;height: 115px"><input class="FindRoadMarking" style="width: 100px" type="text" ></td>' +
                           '<td style="width: 167px;height: 115px"></td><td style="width: 117px"></td>' +
                           '<td style="width: 115px;vertical-align: middle"></td><td style="vertical-align: middle"></td>' +
                           '<td><a class="lastB" href="#">Удалить строку</a></td>';

        $("#ModalMackUp > div > div > div.modal-body > table > tbody > tr:eq(1)").empty().html(mkp);
        $("#ModalMackUp > div > div > div.modal-body > table > tbody > tr:gt(1)").remove();


        $('[data-target="#ModalRoadSigns' + par + '"]').removeClass("btn-danger");
        $('[data-target="#ModalRoadSigns' + par + '"]').addClass("btn-default");
    }

    function cleaningRoadBarriers(par) {

        var mkp =
                    '<td style="width: 185px;height: 115px"><input type="text" class="FindRoadBarriers"></td>' +
                    '<td style="width: 115px;height: 115px"></td><td style="width: 117px"></td>' +
                    '<td style="vertical-align: middle"></td><td><a class="lastA" href="#">Удалить строку</a></td>';

        $("#RoadBarriers1 > div > div > div.modal-body > table > tbody > tr:eq(1)").empty().html(mkp);
        $("#RoadBarriers1 > div > div > div.modal-body > table > tbody > tr:gt(1)").remove();
        $('[data-target="#RoadBarriers' + par + '"]').removeClass("btn-danger");
        $('[data-target="#RoadBarriers' + par + '"]').addClass("btn-default");
    }

