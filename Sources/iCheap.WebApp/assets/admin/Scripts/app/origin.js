$(function () {
    var self = this;
    var origins = []

    self.init = function () {
        self.dataGrid = $("#grdOrigin").dxDataGrid({
            dataSource: origins,
            allowColumnReordering: true,
            allowColumnResizing: true,
            columnAutoWidth: true,
            filterRow: {
                visible: true,
                showAllText: '(Show All)',
                showOperationChooser: true
            },
            editing: {
                allowDeleting: true
            },
            onContentReady: function () {
                $("#hideButton").remove();
                var hideButton = $("<div id='hideButton'>").dxButton({
                    text: "Add new",
                    onClick: function () {
                        $("#popOrigin").dxPopup("instance").show();
                        //alert('Test button add new');
                    }
                });
                $("#grdOrigin").find('.dx-datagrid-header-panel').append(hideButton);
                //$("#start").remove();
                //$("#stop").remove();
                //if ($("#start").length <= 0 && $("#stop").length <= 0) {
                //    $("#grdOrigin").find('.dx-datagrid-header-panel')
                //    .append("<a href='#' id='stop' class='btn btn-addon btn-danger' style='float: right; margin-left: 10px;margin-bottom: 10px;'><i class='fa fa-stop'></i>STOP</a>")
                //}
            },
            //onInitNewRow: function (info) {
            //    //info.data.format = 'paperback';
            //    self.popupDetail.show();
            //    info.cancel = true;
            //},
            selection: {
                mode: 'row'
            },
            searchPanel: {
                visible: true,
                highlightSearchText: true
            },
            paging: { pageSize: 10 },
            pager: {
                showNavigationButtons: true,
                showPageSizeSelector: true,
                showInfo: true,
                allowedPageSizes: [10, 20, 50]
            },
            showBorders: true,
            showRowLines: true,
            scrolling: { mode: 'standard' },
            wordWrapEnabled: true,
            hoverStateEnabled: true,
            columns: [
                {
                    width: '30%',
                    dataField: 'originCode',
                    caption: 'Code',
                    dataType: 'string',
                    validationRules: [{ type: 'required' }]
                },
                {
                    width: '30%',
                    dataField: 'vnName',
                    caption: 'VN Name',
                    dataType: 'string',
                    validationRules: [{ type: 'required' }]
                },
                {
                    width: '30%',
                    dataField: 'enName',
                    caption: 'EN Name',
                    dataType: 'string',
                    validationRules: [{ type: 'required' }]
                },
                {
                    width: '10%',
                    dataField: 'inActive',
                    caption: 'Active',
                    dataType: 'boolean',
                }
            ],
            onRowInserting: function (info) {
                //$.each(websites, function () {
                //    if (this.name === info.data.name) {
                //        info.cancel = true;
                //        ShowMessage(false, 'Duplicate website information! Please try again.');
                //        return false;
                //    }
                //});
            },
            onRowInserted: function (info) {
                //var _data = ko.toJSON(info.data);
                //$.ajax({
                //    type: 'POST',
                //    url: url + "/add",
                //    data: _data,
                //    contentType: 'application/json; charset=utf-8',
                //    dataType: 'json'
                //}).done(function (data) {
                //    ShowMessage(data.ResultCode, data.ResultMessage);

                //    self.loadData();
                //});
            },
            onRowUpdating: function (info) {
                //var name = info.newData.name !== undefined ? info.newData.name : info.oldData.name;
                //var websiteId = info.key.websiteId;
                //$.each(websites, function () {
                //    if (this.name === name && this.websiteId !== websiteId) {
                //        info.cancel = true;
                //        ShowMessage(false, 'Duplicate website information! Please try again.');
                //        return false;
                //    }
                //});
            },
            onRowUpdated: function (info) {
                //var _data = ko.toJSON(info.key);
                //$.ajax({
                //    type: 'POST',
                //    url: url + "/update",
                //    data: _data,
                //    contentType: 'application/json; charset=utf-8',
                //    dataType: 'json'
                //}).done(function (data) {
                //    ShowMessage(data.ResultCode, data.ResultMessage);

                //    self.loadData();
                //});
            },
            onRowRemoving: function (info) {
                //var _data = ko.toJSON(info.data);
                //$.ajax({
                //    type: 'POST',
                //    url: url + "/remove",
                //    data: _data,
                //    contentType: 'application/json; charset=utf-8',
                //    dataType: 'json'
                //}).done(function (data) {
                //    if (!data.ResultCode)
                //        info.cancel = true;

                //    ShowMessage(data.ResultCode, data.ResultMessage);
                //});
            },
            onRowRemoved: function (info) {
                //console.log('da xoa');

                //self.loadData();
            },
        }).dxDataGrid('instance');

        self.popupDetail = $("#popOrigin").dxPopup({
            fullScreen: false,
            titleTemplate: function (titleElement) {
                titleElement.append("<h1>My popup</h1>");
                //var showButtonCheckBox = $("<div>");
                //showButtonCheckBox.dxCheckBox({
                //    text: 'Show "Hide popup" button',
                //    value: true,
                //    onValueChanged: function (e) {
                //        $("#hideButton").dxButton("instance").option("visible", e.value);
                //    }
                //});
                //titleElement.append(showButtonCheckBox);
            },
            height: '80%',
            width: '80%',
            buttons: [
                { toolbar: 'top', location: 'before', widget: 'button', options: { type: 'back', text: 'Back' } },
                { toolbar: 'top', location: 'center', text: 'Products' },
                { toolbar: 'top', location: 'menu', text: 'Add' },
                { toolbar: 'top', location: 'menu', text: 'Remove' },
                { toolbar: 'top', location: 'menu', text: 'Clear' },
                { toolbar: 'bottom', location: 'before', widget: 'button', options: { text: 'Load' } },
                {
                    toolbar: 'bottom', location: 'before', widget: 'button', options: {
                        text: 'Save', onClick: function () {
                            alert('Test save button');
                            $("#popOrigin").dxPopup("instance").hide();
                        }
                    }
                }
            ],
            closeOnOutsideClick: function (e) {
                return e.target !== $("#popOrigin").get()[0];
            }
            //contentTemplate: function (contentElement) {
            //    contentElement.append("<p>The popup content.</p>");
            //    var hideButton = $("<div id='hideButton'>").dxButton({
            //        text: "Hide popup",
            //        onClick: function () {
            //            $("#popOrigin").dxPopup("instance").hide();
            //        }
            //    });
            //    contentElement.append(hideButton);
            //}
        }).dxPopup("instance");
    }
    self.init();
    //self.popupDetail.show();
});