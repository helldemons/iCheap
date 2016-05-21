$(function () {
    var self = this;
    var products = []
    var productItem = {};
    var origins = [];
    var brands = [];
    var categories = [];
    var warrantyType = [
        {
            id: 1,
            vnName: 'Ngày',
            enName: 'Day'
        },
        {
            id: 2,
            vnName: 'Tháng',
            enName: 'Month'
        },
        {
            id: 3,
            vnName: 'Năm',
            enName: 'Year'
        }
    ];
    
    self.loadData = function (){
        $.getJSON(urlOrigin, function (response) {
            origins = response.data;
            $.getJSON(urlBrand, function (response) {
                brands = response.data;
                $.getJSON([urlCategory, '/combobox'].join(''), function (response) {
                    categories = response.data;
                    $.getJSON(url, function (response) {
                        products = response.data;
                        $('#grdProduct').dxDataGrid('instance').option('dataSource', products);
                    });
                });
            });
        });
    };
    
    self.init = function () {
        self.popupDetail = $("#popProduct").dxPopup({
            fullScreen: false,
            title: 'Thông Tin Hàng Hóa',
            height: '80%',
            width: '90%',
            buttons: [
                {
                    toolbar: 'bottom', location: 'before', widget: 'button', options: {
                        text: 'Lưu & Đóng', onClick: function () {
                            self.saveData(true);
                        }
                    }
                },
                {
                    toolbar: 'bottom', location: 'before', widget: 'button', options: {
                        text: 'Lưu & Thêm',
                        onClick: function () {
                            self.saveData(false);
                        }
                    }
                },
                {
                    toolbar: 'bottom', location: 'before', widget: 'button', options: {
                        text: 'Hủy Bỏ', onClick: function () {
                            $("#popProduct").dxPopup("instance").hide();
                        }
                    }
                }
            ],
            closeOnOutsideClick: function (e) {
                return e.target !== $("#popProduct").get()[0];
            }
        }).dxPopup("instance");

        self.dataGrid = $("#grdProduct").dxDataGrid({
            dataSource: products,
            allowColumnReordering: true,
            allowColumnResizing: true,
            columnAutoWidth: true,
            filterRow: {
                visible: true,
                showAllText: '(Tất Cả)',
                showOperationChooser: true
            },
            editing: {
                allowDeleting: true,
                texts: {
                    deleteRow: 'Xóa',
                    undeleteRow: 'Hủy Bỏ'
                }
            },
            onContentReady: function () {
                $("#addNewButton").remove();
                $("#reloadButton").remove();
                $("#grdProduct").find('.dx-datagrid-header-panel')
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
            paging: { pageSize: 15 },
            pager: {
                showNavigationButtons: true,
                showPageSizeSelector: true,
                showInfo: true,
                allowedPageSizes: [10, 15, 30, 50]
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
                    width: '10%',
                    dataField: 'productCode',
                    caption: 'Mã hàng',
                    dataType: 'string',
                    cellTemplate: function (container, options) {
                        $("<span class='gridbutton-arrowleft' />")
                        .text(options.text)
                        .css({ "text-decoration": "underline", "font-weight": "bold" })
                        .on('click', function () {
                            $.getJSON([url , '/', options.data.productId].join(''), function (response) {
                                self.openForm(response.data);
                            });
                        })
                        .appendTo(container);
                    }
                },
                {
                    width: '20%',
                    dataField: 'vnName',
                    caption: 'Tên tiếng Việt',
                    dataType: 'string'
                },
                {
                    width: '20%',
                    dataField: 'enName',
                    caption: 'Tên tiếng Anh',
                    dataType: 'string'
                },
                {
                    width: '20%',
                    dataField: 'category.vnName',
                    caption: 'Nhóm hàng hóa',
                    dataType: 'string'
                },
                {
                    width: '10%',
                    dataField: 'originalPrice',
                    caption: 'Giá gốc',
                    dataType: 'number',
                    cellTemplate: function (container, options) {
                        $('<span>').html(addCommas(options.value)).appendTo(container);
                    }
                },
                {
                    width: '10%',
                    dataField: 'marketPrice',
                    caption: 'Giá thị trường',
                    dataType: 'number',
                    cellTemplate: function (container, options) {
                        $('<span>').html(addCommas(options.value)).appendTo(container);
                    }
                },
                {
                    width: '10%',
                    dataField: 'price',
                    caption: 'Giá bán',
                    dataType: 'number',
                    cellTemplate: function (container, options) {
                        $('<span>').html(addCommas(options.value)).appendTo(container);
                    }
                },
                {
                    width: '5%',
                    dataField: 'rank',
                    caption: 'Thứ tự',
                    dataType: 'number',
                },
                {
                    width: '10%',
                    dataField: 'inActive',
                    caption: 'Đang dùng',
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
        productItem = d;
        var form = $("<div id='productForm'>").dxForm({
            formData: productItem,
            labelLocation: 'left',
            showOptionalMark: '*',
            optionalMark: '',
            scrollingEnabled: true,
            onFieldDataChanged: function (model) {
                productItem[model.dataField] = model.value;
            },
            customizeItem: function (item) {
                switch (item.dataField) {
                    case "productCode":
                    case "vnName":
                    case "enName":
                    case "vnRewriteUrl":
                    case "enRewriteUrl":
                        item.validationRules = [{
                            type: "required",
                            message: "Trường dữ liệu này không được để trống!"
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
                                text: 'Mã hàng hóa'
                            },
                            dataField: 'productCode',
                            isRequired: true,
                            editorType: 'dxTextBox',
                            template: function (data, itemElement) {
                                var textBox = $("<div id='productCode'>");
                                textBox.dxTextBox({
                                    value: data.editorOptions.value,
                                    onValueChanged: function (e) {
                                        d["productCode"] = getDataCode(e.value);
                                        $("#productCode").dxTextBox("instance").option("value", getDataCode(e.value));
                                    }
                                });

                                textBox.appendTo(itemElement);
                            }
                        },
                        {
                            label: {
                                text: 'Nhóm'
                            },
                            dataField: 'category.categoryId',
                            isRequired: true,
                            editorType: 'dxSelectBox',
                            template: function (data, itemElement) {
                                var cboCategory = $("<div id='cboCategory'>");
                                cboCategory.dxSelectBox({
                                    dataSource: categories,
                                    searchEnabled: true,
                                    placeholder: 'Chọn nhóm bất kỳ',
                                    displayExpr: 'vnName',
                                    valueExpr: 'categoryId',
                                    value: data.editorOptions.value,
                                    itemTemplate: function (itemData, itemIndex, itemElement) {
                                        itemElement.append($('<span>').text(itemData.vnName));
                                    },
                                    onValueChanged: function (e) {
                                        productItem["category"] = e.itemData;
                                    }
                                });

                                cboCategory.appendTo(itemElement);
                            }
                        },
                        { itemType: 'empty', colSpan: 2 },
                        {
                            label: {
                                text: 'Tên tiếng Việt'
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
                                text: 'Rewrite URL VN'
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
                                text: 'Tên tiếng Anh'
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
                                        productItem["enName"] = e.value;
                                        productItem["enRewriteUrl"] = getRewriteUrl(e.value);
                                        $("#enRewriteUrl").dxTextBox("instance").option("value", getRewriteUrl(e.value));
                                    }
                                });

                                textBox.appendTo(itemElement);
                            }
                        },
                        {
                            label: {
                                text: 'Rewrite URL EN'
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
                                    title: 'Thông tin chung',
                                    colCount: 4,
                                    items: [
                                        {
                                            label: {
                                                text: 'Giá gốc'
                                            },
                                            dataField: 'originalPrice',
                                            colSpan: 1,
                                            isRequired: true,
                                            editorType: 'dxNumberBox',
                                            template: function (data, itemElement) {
                                                var price = $("<div>");
                                                price.dxNumberBox({
                                                    min: 0,
                                                    step: 5000,
                                                    placeholder: 'Giá gốc',
                                                    showClearButton: true,
                                                    showSpinButtons: true,
                                                    value: data.editorOptions.value,
                                                    onValueChanged: function (e) {
                                                        productItem["originalPrice"] = e.value;
                                                    }
                                                });

                                                price.appendTo(itemElement);
                                            }
                                        },
                                        {
                                            label: {
                                                text: 'Giá thị trường'
                                            },
                                            dataField: 'marketPrice',
                                            colSpan: 1,
                                            isRequired: true,
                                            editorType: 'dxNumberBox',
                                            template: function (data, itemElement) {
                                                var price = $("<div>");
                                                price.dxNumberBox({
                                                    min: 0,
                                                    step: 5000,
                                                    placeholder: 'Giá thị trường',
                                                    showClearButton: true,
                                                    showSpinButtons: true,
                                                    value: data.editorOptions.value,
                                                    onValueChanged: function (e) {
                                                        productItem["marketPrice"] = e.value;
                                                    }
                                                });

                                                price.appendTo(itemElement);
                                            }
                                        },
                                        {
                                            label: {
                                                text: 'Giá bán'
                                            },
                                            dataField: 'price',
                                            colSpan: 1,
                                            isRequired: true,
                                            editorType: 'dxNumberBox',
                                            template: function (data, itemElement) {
                                                var price = $("<div>");
                                                price.dxNumberBox({
                                                    min: 0,
                                                    step: 5000,
                                                    placeholder: 'Giá bán',
                                                    showClearButton: true,
                                                    showSpinButtons: true,
                                                    value: data.editorOptions.value,
                                                    onValueChanged: function (e) {
                                                        productItem["price"] = e.value;
                                                        self.changeDiscount(productItem, 0);
                                                    }
                                                });

                                                price.appendTo(itemElement);
                                            }
                                        },
                                        {
                                            label: {
                                                visible: false
                                            },
                                            dataField: 'available',
                                            colSpan: 1,
                                            editorType: 'dxCheckBox',
                                            template: function (data, itemElement) {
                                                var checkBox = $("<div>");
                                                checkBox.dxCheckBox({
                                                    text: 'Hàng có sẵn?',
                                                    value: data.editorOptions.value,
                                                    onValueChanged: function (e) {
                                                        productItem["available"] = e.value;
                                                    }
                                                });

                                                checkBox.appendTo(itemElement);
                                            }
                                        },
                                        {
                                            label: {
                                                visible: false
                                            },
                                            dataField: 'inNew',
                                            colSpan: 1,
                                            editorType: 'dxCheckBox',
                                            template: function (data, itemElement) {
                                                var checkBox = $("<div>");
                                                checkBox.dxCheckBox({
                                                    text: 'Hàng mới nhập?',
                                                    value: data.editorOptions.value,
                                                    onValueChanged: function (e) {
                                                        productItem["inNew"] = e.value;
                                                    }
                                                });

                                                checkBox.appendTo(itemElement);
                                            }
                                        },
                                        {
                                            label: {
                                                visible: false
                                            },
                                            dataField: 'inHot',
                                            colSpan: 1,
                                            editorType: 'dxCheckBox',
                                            template: function (data, itemElement) {
                                                var checkBox = $("<div>");
                                                checkBox.dxCheckBox({
                                                    text: 'Hàng đang hot?',
                                                    value: data.editorOptions.value,
                                                    onValueChanged: function (e) {
                                                        productItem["inHot"] = e.value;
                                                    }
                                                });

                                                checkBox.appendTo(itemElement);
                                            }
                                        },
                                        {
                                            label: {
                                                visible: false
                                            },
                                            dataField: 'inBestSale',
                                            colSpan: 1,
                                            editorType: 'dxCheckBox',
                                            template: function (data, itemElement) {
                                                var checkBox = $("<div>");
                                                checkBox.dxCheckBox({
                                                    text: 'Hàng bán chạy nhất?',
                                                    value: data.editorOptions.value,
                                                    onValueChanged: function (e) {
                                                        productItem["inBestSale"] = e.value;
                                                    }
                                                });

                                                checkBox.appendTo(itemElement);
                                            }
                                        },
                                        {
                                            label: {
                                                visible: false
                                            },
                                            dataField: 'inSaleOff',
                                            colSpan: 1,
                                            editorType: 'dxCheckBox',
                                            template: function (data, itemElement) {
                                                var checkBox = $("<div>");
                                                checkBox.dxCheckBox({
                                                    text: 'Hàng đang khuyến mãi?',
                                                    value: data.editorOptions.value,
                                                    onValueChanged: function (e) {
                                                        productItem["inSaleOff"] = e.value;
                                                    }
                                                });

                                                checkBox.appendTo(itemElement);
                                            }
                                        },
                                        {
                                            label: {
                                                text: 'Xuất xứ'
                                            },
                                            dataField: 'origin.originId',
                                            colSpan: 1,
                                            editorType: 'dxSelectBox',
                                            template: function (data, itemElement) {
                                                var cboOrigin = $("<div id='cboOringin'>");
                                                cboOrigin.dxSelectBox({
                                                    dataSource: origins,
                                                    searchEnabled: true,
                                                    placeholder: 'Chọn xuất xứ bất kỳ',
                                                    displayExpr: 'vnName',
                                                    valueExpr: 'originId',
                                                    value: data.editorOptions.value,
                                                    itemTemplate: function (itemData, itemIndex, itemElement) {
                                                        itemElement.append($('<span>').text([itemData.originCode, '-', itemData.vnName].join(' ')));
                                                    },
                                                    onValueChanged: function (e) {
                                                        //productItem.origin.originId = e.value;
                                                        productItem["origin"] = e.itemData;
                                                    }
                                                });

                                                cboOrigin.appendTo(itemElement);
                                            }
                                        },
                                        {
                                            label: {
                                                text: 'Thương hiệu'
                                            },
                                            dataField: 'brand.brandId',
                                            colSpan: 1,
                                            editorType: 'dxSelectBox',
                                            template: function (data, itemElement) {
                                                var cboBrand = $("<div id='cboBrand'>");
                                                cboBrand.dxSelectBox({
                                                    dataSource: brands,
                                                    searchEnabled: true,
                                                    placeholder: 'Chọn thương hiệu bất kỳ',
                                                    displayExpr: 'vnName',
                                                    valueExpr: 'brandId',
                                                    value: data.editorOptions.value,
                                                    itemTemplate: function (itemData, itemIndex, itemElement) {
                                                        itemElement.append($('<span>').text([itemData.brandCode, '-', itemData.vnName].join(' ')));
                                                    },
                                                    onValueChanged: function (e) {
                                                        //productItem.brand.brandId = e.value;
                                                        productItem["brand"] = e.itemData;
                                                    }
                                                });

                                                cboBrand.appendTo(itemElement);
                                            }
                                        },
                                        {
                                            itemType: 'group',
                                            colCount: 3,
                                            colSpan: 2,
                                            items: [
                                                {
                                                    label: {
                                                        visible: false
                                                    },
                                                    dataField: 'inWarranty',
                                                    colSpan: 1,
                                                    editorType: 'dxCheckBox',
                                                    template: function (data, itemElement) {
                                                        var checkBox = $("<div>");
                                                        checkBox.dxCheckBox({
                                                            text: 'Có bảo hành?',
                                                            value: data.editorOptions.value,
                                                            onValueChanged: function (e) {
                                                                productItem["inWarranty"] = e.value;
                                                            }
                                                        });

                                                        checkBox.appendTo(itemElement);
                                                    }
                                                },
                                                {
                                                    label: {
                                                        text: 'Thời gian'
                                                    },
                                                    dataField: 'warranty',
                                                    colSpan: 1,
                                                    editorType: 'dxNumberBox',
                                                    template: function (data, itemElement) {
                                                        var price = $("<div>");
                                                        price.dxNumberBox({
                                                            min: 0,
                                                            step: 1,
                                                            showClearButton: true,
                                                            showSpinButtons: true,
                                                            value: data.editorOptions.value,
                                                            onValueChanged: function (e) {
                                                                productItem["warranty"] = e.value;
                                                            }
                                                        });

                                                        price.appendTo(itemElement);
                                                    }
                                                },
                                                {
                                                    label: {
                                                        visible: false
                                                    },
                                                    dataField: 'warrantyType',
                                                    colSpan: 1,
                                                    editorType: 'dxSelectBox',
                                                    template: function (data, itemElement) {
                                                        var cboWarrantyType = $("<div id='cboWarrantyType'>");
                                                        cboWarrantyType.dxSelectBox({
                                                            dataSource: warrantyType,
                                                            displayExpr: 'vnName',
                                                            valueExpr: 'id',
                                                            value: data.editorOptions.value,
                                                            onValueChanged: function (e) {
                                                                productItem["warrantyType"] = e.value;
                                                            }
                                                        });

                                                        cboWarrantyType.appendTo(itemElement);
                                                    }
                                                }
                                            ]
                                        },
                                        {
                                            label: {
                                                text: 'Số lượng đạt mức giảm giá'
                                            },
                                            dataField: 'discountQuantity',
                                            colSpan: 2,
                                            editorType: 'dxNumberBox',
                                            template: function (data, itemElement) {
                                                var discountQuantity = $("<div>");
                                                discountQuantity.dxNumberBox({
                                                    min: 10,
                                                    step: 10,
                                                    placeholder: 'Số lượng',
                                                    showClearButton: true,
                                                    showSpinButtons: true,
                                                    value: data.editorOptions.value,
                                                    onValueChanged: function (e) {
                                                        productItem["discountQuantity"] = e.value;
                                                    }
                                                });

                                                discountQuantity.appendTo(itemElement);
                                            }
                                        },
                                        {
                                            label: {
                                                text: 'Tỉ lệ giảm giá'
                                            },
                                            dataField: 'discountRate',
                                            colSpan: 1,
                                            editorType: 'dxNumberBox',
                                            template: function (data, itemElement) {
                                                var discountRate = $("<div id='discountRate'>");
                                                discountRate.dxNumberBox({
                                                    min: 0,
                                                    step: 0.5,
                                                    placeholder: 'Tỉ lệ',
                                                    showClearButton: true,
                                                    showSpinButtons: true,
                                                    value: data.editorOptions.value,
                                                    onValueChanged: function (e) {
                                                        productItem["discountRate"] = e.value;
                                                        self.changeDiscount(productItem, 1);
                                                    }
                                                });

                                                discountRate.appendTo(itemElement);
                                            }
                                        },
                                        {
                                            label: {
                                                text: 'Mức giảm'
                                            },
                                            dataField: 'discountAmount',
                                            colSpan: 1,
                                            editorType: 'dxNumberBox',
                                            template: function (data, itemElement) {
                                                var discountAmount = $("<div id='discountAmount'>");
                                                discountAmount.dxNumberBox({
                                                    min: 0,
                                                    step: 5000,
                                                    placeholder: 'Mức giảm',
                                                    showClearButton: true,
                                                    showSpinButtons: true,
                                                    value: data.editorOptions.value,
                                                    onValueChanged: function (e) {
                                                        productItem["discountAmount"] = e.value;
                                                        self.changeDiscount(productItem, 2);
                                                    }
                                                });

                                                discountAmount.appendTo(itemElement);
                                            }
                                        },
                                    ]
                                },
                                {
                                    title: 'Thông tin sản phẩm VN',
                                    items: [
                                        {
                                            label: {
                                                visible: false
                                            },
                                            dataField: 'vnFullInformation',
                                            editorType: 'dxTextArea',
                                            template: function (data, itemElement) {
                                                var vnFullInformation = $("<div>");
                                                vnFullInformation.dxTextArea({
                                                    value: data.editorOptions.value,
                                                    height: '250px',
                                                    onValueChanged: function (e) {
                                                        productItem["vnFullInformation"] = e.value;
                                                    }
                                                });

                                                vnFullInformation.appendTo(itemElement);
                                            }
                                        },
                                    ]
                                },
                                {
                                    title: 'Thông tin sản phẩm EN',
                                    items: [
                                        {
                                            label: {
                                                visible: false
                                            },
                                            dataField: 'enFullInformation',
                                            editorType: 'dxTextArea',
                                            template: function (data, itemElement) {
                                                var enFullInformation = $("<div>");
                                                enFullInformation.dxTextArea({
                                                    value: data.editorOptions.value,
                                                    height: '250px',
                                                    onValueChanged: function (e) {
                                                        productItem["enFullInformation"] = e.value;
                                                    }
                                                });

                                                enFullInformation.appendTo(itemElement);
                                            }
                                        },
                                    ]
                                },
                                {
                                    title: 'SEO',
                                    items: [
                                        {
                                            label: {
                                                text: 'Tên SEO VN'
                                            },
                                            dataField: 'vnNameSEO',
                                            colSpan: 4
                                        },
                                        {
                                            label: {
                                                text: 'Tên SEO EN'
                                            },
                                            dataField: 'enNameSEO',
                                            colSpan: 4
                                        },
                                        {
                                            label: {
                                                text: 'Mô tả VN'
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
                                                        productItem["vnDescription"] = e.value;
                                                    }
                                                });

                                                textArea.appendTo(itemElement);
                                            }
                                        },
                                        {
                                            label: {
                                                text: 'Mô tả EN'
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
                                                        productItem["enDescription"] = e.value;
                                                    }
                                                });

                                                textArea.appendTo(itemElement);
                                            }
                                        },
                                        {
                                            label: {
                                                text: 'Từ khóa'
                                            },
                                            dataField: 'tag',
                                            colSpan: 4,
                                            editorType: 'dxTextArea',
                                            helpText: 'Ví dụ: từ khóa 1, từ khóa 2...',
                                            template: function (data, itemElement) {
                                                var textArea = $("<div>");
                                                textArea.dxTextArea({
                                                    value: data.editorOptions.value,
                                                    height: '60px',
                                                    onValueChanged: function (e) {
                                                        productItem["tag"] = e.value;
                                                    }
                                                });

                                                textArea.appendTo(itemElement);
                                            }
                                        }
                                    ]
                                },
                                {
                                    title: 'Thông tin khác',
                                    colCount: 4,
                                    items: [
                                        {
                                            label: {
                                                text: 'Ảnh'
                                            },
                                            dataField: 'thumbnail',
                                            colSpan: 4
                                        },
                                        {
                                            label: {
                                                text: 'Ảnh sản phẩm'
                                            },
                                            dataField: 'images',
                                            colSpan: 2,
                                            editorType: 'dxTextArea',
                                            template: function (data, itemElement) {
                                                var textArea = $("<div>");
                                                textArea.dxTextArea({
                                                    value: data.editorOptions.value,
                                                    height: '80px',
                                                    onValueChanged: function (e) {
                                                        productItem["images"] = e.value;
                                                    }
                                                });

                                                textArea.appendTo(itemElement);
                                            }
                                        },
                                        {
                                            label: {
                                                text: 'Video sản phẩm'
                                            },
                                            dataField: 'videos',
                                            colSpan: 2,
                                            editorType: 'dxTextArea',
                                            template: function (data, itemElement) {
                                                var textArea = $("<div>");
                                                textArea.dxTextArea({
                                                    value: data.editorOptions.value,
                                                    height: '80px',
                                                    onValueChanged: function (e) {
                                                        productItem["videos"] = e.value;
                                                    }
                                                });

                                                textArea.appendTo(itemElement);
                                            }
                                        },
                                        { itemType: 'empty', colSpan: 4 },
                                        {
                                            label: {
                                                text: 'Thứ tự'
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
                                                    text: 'Đang theo dõi?',
                                                    value: data.editorOptions.value,
                                                    onValueChanged: function (e) {
                                                        productItem["inActive"] = e.value;
                                                    }
                                                });

                                                checkBox.appendTo(itemElement);
                                            }
                                        },
                                        {
                                            label: {
                                                text: 'Ghi chú'
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
                                                        productItem["note"] = e.value;
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
        $("#popProduct").dxPopup("instance").option('contentTemplate', function (c) {
            c.append(self.getForm(d));
        });
        $("#popProduct").dxPopup("instance").show();
    };

    self.closeForm = function () {
        $("#popProduct").dxPopup("instance").hide();
    }
    
    self.saveData = function (c){
        if ($('#productForm').dxForm("instance").validate().isValid) {
            var isInsert = productItem.productId === undefined;
            var isCanSave = true;

            if (isInsert) {
                $.each(products, function () {
                    if (this.productCode === productItem["productCode"]) {
                        showMessage(false, 'Thông tin hàng hóa đã bị trùng! Vui lòng thử lại!');
                        isCanSave = false;
                        return false;
                    }
                });
            }
            else {
                $.each(products, function () {
                    if (this.productCode === productItem["productCode"] && this.productId !== productItem["productId"]) {
                        showMessage(false, 'Thông tin hàng hóa đã bị trùng! Vui lòng thử lại!');
                        isCanSave = false;
                        return false;
                    }
                });
            }
            if (isCanSave) {
                var _data = ko.toJSON(productItem);
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

    self.changeDiscount = function (p, t) {
        var price = p["price"];
        //var number = p["discountQuantity"];
        var rate = p["discountRate"];
        var money = p["discountAmount"];

        price = isNaN(price) ? 0 : price;
        //number = isNaN(number) ? 0 : number;
        rate = isNaN(rate) ? 0 : rate;
        money = isNaN(money) ? 0 : money;

        if (t === 0 || t === 1) {
            money = (price * rate) / 100;
            p["discountAmount"] = money;
            $('#discountAmount').dxNumberBox('instance').option('value', money);
        }
        else {
            rate = (money / price) * 100;
            p["discountRate"] = rate;
            $('#discountRate').dxNumberBox('instance').option('value', rate);
        }

        //p["price"] = price;
        //p["discountRate"] = rate;
        //p["discountAmount"] = money;
    }
});