$(function () {
    var self = this;
    var brands = []
    var brandItem = {};
    
    self.loadData = function (){
        $.getJSON(url, function (response) {
            brands = response.data;
            $('#grdBrand').dxDataGrid('instance').option('dataSource', brands);
        });
    };
    
    self.init = function () {
        self.popupDetail = $("#popBrand").dxPopup({
            fullScreen: false,
            title: 'Brand Detail',
            height: '80%',
            width: '90%',
            buttons: [
                {
                    toolbar: 'bottom', location: 'before', widget: 'button', options: {
                        text: 'Save & Close', onClick: function () {
                            self.saveData(true);
                        }
                    }
                },
                {
                    toolbar: 'bottom', location: 'before', widget: 'button', options: {
                        text: 'Save & Add',
                        onClick: function () {
                            self.saveData(false);
                        }
                    }
                },
                {
                    toolbar: 'bottom', location: 'before', widget: 'button', options: {
                        text: 'Cancel', onClick: function () {
                            $("#popBrand").dxPopup("instance").hide();
                        }
                    }
                }
            ],
            closeOnOutsideClick: function (e) {
                return e.target !== $("#popBrand").get()[0];
            }
        }).dxPopup("instance");

        self.dataGrid = $("#grdBrand").dxDataGrid({
            dataSource: brands,
            allowColumnReordering: true,
            allowColumnResizing: true,
            columnAutoWidth: true,
            filterRow: {
                visible: true,
                showAllText: '(Show All)',
                showOperationChooser: true
            },
            editing: {
                mode: 'batch',
                allowDeleting: true
            },
            onContentReady: function () {
                $("#addNewButton").remove();
                $("#reloadButton").remove();
                $("#grdBrand").find('.dx-datagrid-header-panel')
                    .append($("<div id='reloadButton'>").dxButton({
                        icon: 'refresh',
                        onClick: function () {
                            self.loadData();
                        }
                    }))
                    .append($("<div id='addNewButton'>").dxButton({
                    icon: 'add',
                    onClick: function () {
                        self.openForm({});
                    }
                }));
            },
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
                    width: '5%',
                    caption: '#',
                    dataType: 'string',
                    alignment: 'center',
                    cellTemplate: function (container, options) {
                        $("<span class='gridbutton-arrowleft' />")
                        .text(options.rowIndex + 1)
                        .appendTo(container);
                    }
                },
                {
                    width: '20%',
                    dataField: 'brandCode',
                    caption: 'Code',
                    dataType: 'string',
                    cellTemplate: function (container, options) {
                        $("<span class='gridbutton-arrowleft' />")
                        .text(options.text)
                        .css({ "text-decoration": "underline", "font-weight": "bold" })
                        .on('click', function () {
                            $.getJSON([url , '/', options.data.brandId].join(''), function (response) {
                                self.openForm(response.data);
                            });
                        })
                        .appendTo(container);
                    }
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
                    dataField: 'rank',
                    caption: 'Rank',
                    dataType: 'number',
                },
                {
                    width: '10%',
                    dataField: 'inActive',
                    caption: 'Active',
                    dataType: 'boolean',
                }
            ],
            onRowRemoving: function (info) {
                var _data = ko.toJSON(info.data);
                $.ajax({
                    type: 'POST',
                    url: [url, '/remove'].join(''),
                    data: _data,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json'
                }).done(function (data) {
                    if (!data.Status)
                        info.cancel = true;

                    ShowMessage(data.Status, data.Message);
                });
            },
            onRowRemoved: function (info) {
                self.loadData();
            },
        }).dxDataGrid('instance');

        self.loadData();
    };

    self.getForm = function (d) {
        brandItem = d;
        var form = $("<div id='brandForm'>").dxForm({
            formData: brandItem,
            labelLocation: 'left',
            showOptionalMark: '*',
            optionalMark: '',
            scrollingEnabled: true,
            onFieldDataChanged: function (model) {
                brandItem[model.dataField] = model.value;
            },
            customizeItem: function (item) {
                switch (item.dataField) {
                    case "brandCode":
                    case "vnName":
                    case "enName":
                    case "vnRewriteUrl":
                    case "enRewriteUrl":
                        item.validationRules = [{
                            type: "required",
                            message: "This field must not be empty!"
                        }];
                        break;
                }
            },
            items: [
                {
                    itemType: 'group',
                    colCount: 4,
                    items: [
                        {
                            label: {
                                text: 'Brand code'
                            },
                            dataField: 'brandCode',
                            isRequired: true,
                            editorType: 'dxTextBox',
                            template: function (data, itemElement) {
                                var textBox = $("<div id='brandCode'>");
                                textBox.dxTextBox({
                                    value: data.editorOptions.value,
                                    onValueChanged: function (e) {
                                        d["brandCode"] = getDataCode(e.value);
                                        $("#brandCode").dxTextBox("instance").option("value", getDataCode(e.value));
                                    }
                                });

                                textBox.appendTo(itemElement);
                            }
                        },
                        { itemType: 'empty', colSpan: 3 },
                        {
                            label: {
                                text: 'VN Name'
                            },
                            dataField: 'vnName',
                            colSpan: 2,
                            isRequired: true,
                            editorType: 'dxTextBox',
                            template: function (data, itemElement) {
                                var textBox = $("<div>");
                                textBox.dxTextBox({
                                    value: data.editorOptions.value,
                                    onValueChanged: function (e) {
                                        d["vnName"] = e.value;
                                        d["vnRewriteUrl"] = getRewriteUrl(e.value);
                                        $("#vnRewriteUrl").dxTextBox("instance").option("value", getRewriteUrl(e.value));
                                    }
                                });

                                textBox.appendTo(itemElement);
                            }
                        },
                        {
                            label: {
                                text: 'VN Rewrite URL'
                            },
                            dataField: 'vnRewriteUrl',
                            colSpan: 2,
                            isRequired: true,
                            editorType: 'dxTextBox',
                            template: function (data, itemElement) {
                                var textBox = $("<div id='vnRewriteUrl'>");
                                textBox.dxTextBox({
                                    value: data.editorOptions.value,
                                    readOnly: true
                                });

                                textBox.appendTo(itemElement);
                            }
                        },
                        {
                            label: {
                                text: 'EN Name'
                            },
                            dataField: 'enName',
                            colSpan: 2,
                            isRequired: true,
                            editorType: 'dxTextBox',
                            template: function (data, itemElement) {
                                var textBox = $("<div>");
                                textBox.dxTextBox({
                                    value: data.editorOptions.value,
                                    onValueChanged: function (e) {
                                        brandItem["enName"] = e.value;
                                        brandItem["enRewriteUrl"] = getRewriteUrl(e.value);
                                        $("#enRewriteUrl").dxTextBox("instance").option("value", getRewriteUrl(e.value));
                                    }
                                });

                                textBox.appendTo(itemElement);
                            }
                        },
                        {
                            label: {
                                text: 'EN Rewrite URL'
                            },
                            dataField: 'enRewriteUrl',
                            colSpan: 2,
                            isRequired: true,
                            editorType: 'dxTextBox',
                            template: function (data, itemElement) {
                                var textBox = $("<div id='enRewriteUrl'>");
                                textBox.dxTextBox({
                                    value: data.editorOptions.value,
                                    readOnly: true
                                });

                                textBox.appendTo(itemElement);
                            }
                        },
                        {
                            itemType: 'tabbed',
                            tabs: [
                                {
                                    title: 'SEO',
                                    items: [
                                        {
                                            label: {
                                                text: 'VN Name SEO'
                                            },
                                            dataField: 'vnNameSEO',
                                            colSpan: 4
                                        },
                                        {
                                            label: {
                                                text: 'EN Name SEO'
                                            },
                                            dataField: 'enNameSEO',
                                            colSpan: 4
                                        },
                                        {
                                            label: {
                                                text: 'VN Description'
                                            },
                                            dataField: 'vnDescription',
                                            colSpan: 4,
                                            editorType: 'dxTextArea',
                                            template: function (data, itemElement) {
                                                var textArea = $("<div>");
                                                textArea.dxTextArea({
                                                    value: data.editorOptions.value,
                                                    height: '60px',
                                                    onValueChanged: function (e) {
                                                        brandItem["vnDescription"] = e.value;
                                                    }
                                                });

                                                textArea.appendTo(itemElement);
                                            }
                                        },
                                        {
                                            label: {
                                                text: 'EN Description'
                                            },
                                            dataField: 'enDescription',
                                            colSpan: 4,
                                            editorType: 'dxTextArea',
                                            template: function (data, itemElement) {
                                                var textArea = $("<div>");
                                                textArea.dxTextArea({
                                                    value: data.editorOptions.value,
                                                    height: '60px',
                                                    onValueChanged: function (e) {
                                                        brandItem["enDescription"] = e.value;
                                                    }
                                                });

                                                textArea.appendTo(itemElement);
                                            }
                                        },
                                        {
                                            label: {
                                                text: 'Tags'
                                            },
                                            dataField: 'tag',
                                            colSpan: 4,
                                            editorType: 'dxTextArea',
                                            helpText: 'Example: tag1, tag2, tag3',
                                            template: function (data, itemElement) {
                                                var textArea = $("<div>");
                                                textArea.dxTextArea({
                                                    value: data.editorOptions.value,
                                                    height: '60px',
                                                    onValueChanged: function (e) {
                                                        brandItem["tag"] = e.value;
                                                    }
                                                });

                                                textArea.appendTo(itemElement);
                                            }
                                        }
                                    ]
                                },
                                {
                                    title: 'Other information',
                                    colCount: 4,
                                    items: [
                                        {
                                            label: {
                                                text: 'Thumbnail'
                                            },
                                            dataField: 'thumbnail',
                                            colSpan: 4
                                        },
                                        {
                                            label: {
                                                visible: false
                                            },
                                            dataField: 'thumbnail',
                                            colSpan: 4,
                                            template: function (data, itemElement) {
                                                var fileUploader = $("<div>");
                                                fileUploader.dxFileUploader({
                                                    selectButtonText: 'Select file',
                                                    labelText: 'Drop file here',
                                                    multiple: false,
                                                    accept: 'image/*'
                                                });

                                                fileUploader.appendTo(itemElement);
                                            }
                                        },
                                        { itemType: 'empty', colSpan: 4 },
                                        {
                                            label: {
                                                text: 'Rank'
                                            },
                                            dataField: 'rank',
                                            editorType: 'dxNumberBox',
                                            colSpan: 2
                                        },
                                        {
                                            label: {
                                                visible: false
                                            },
                                            dataField: 'inActive',
                                            colSpan: 2,
                                            editorType: 'dxCheckBox',
                                            template: function (data, itemElement) {
                                                var checkBox = $("<div>");
                                                checkBox.dxCheckBox({
                                                    text: 'In active?',
                                                    value: data.editorOptions.value,
                                                    onValueChanged: function (e) {
                                                        brandItem["inActive"] = e.value;
                                                    }
                                                });

                                                checkBox.appendTo(itemElement);
                                            }
                                        },
                                        {
                                            label: {
                                                text: 'Note'
                                            },
                                            dataField: 'note',
                                            colSpan: 4,
                                            editorType: 'dxTextArea',
                                            template: function (data, itemElement) {
                                                var textArea = $("<div>");
                                                textArea.dxTextArea({
                                                    value: data.editorOptions.value,
                                                    height: '80px',
                                                    onValueChanged: function (e) {
                                                        brandItem["note"] = e.value;
                                                    }
                                                });

                                                textArea.appendTo(itemElement);
                                            }
                                        }
                                    ]
                                }
                            ],
                            colSpan: 4
                        }
                    ]
                }
            ]
        });

        return form;
    }

    self.openForm = function (d, o) {
        $("#popBrand").dxPopup("instance").option('contentTemplate', function (c) {
            c.append(self.getForm(d));
        });
        $("#popBrand").dxPopup("instance").show();
    };

    self.closeForm = function () {
        $("#popBrand").dxPopup("instance").hide();
    }
    
    self.saveData = function (c){
        if ($('#brandForm').dxForm("instance").validate().isValid) {
            var isInsert = brandItem.brandId === undefined;
            var isCanSave = true;

            if (isInsert) {
                $.each(brands, function () {
                    if (this.brandCode === brandItem["brandCode"]) {
                        showMessage(false, 'Duplicate brand information. Please try again!');
                        isCanSave = false;
                        return false;
                    }
                });
            }
            else {
                $.each(brands, function () {
                    if (this.brandCode === brandItem["brandCode"] && this.brandId !== brandItem["brandId"]) {
                        showMessage(false, 'Duplicate brand information. Please try again! update');
                        isCanSave = false;
                        return false;
                    }
                });
            }
            if (isCanSave) {
                var _data = ko.toJSON(brandItem);
                $.ajax({
                    type: 'POST',
                    url: [url, '/', isInsert ? 'add' : 'edit'].join(''),
                    data: _data,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json'
                }).done(function (data) {
                    showMessage(data.Status, data.Message);

                    self.loadData();
                    if (c) {
                        self.closeForm();
                    }
                    else {
                        self.openForm({});
                    }
                });
            }
        }
    };

    self.init();
});