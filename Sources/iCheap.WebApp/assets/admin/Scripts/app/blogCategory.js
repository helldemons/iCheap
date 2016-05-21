$(function () {
    var self = this;
    var blogCategories = [];
    var blogCategoryData = [];
    var blogCategoryItem = {};

    self.loadData = function () {
        $.getJSON(url, function (response) {
            blogCategories = response.data;
            $('#grdBlogCategory').dxDataGrid('instance').option('dataSource', blogCategories);

            blogCategoryData = [];
            if (blogCategories !== undefined && blogCategories.length > 0)
                blogCategoryData = $.grep(blogCategories, function (c) {
                    return c.parentId === 0;
                });
            blogCategoryData.unshift({ blogCategoryId: 0, vnName: null, enName: null });
            if ($('#cboBlogCategory').dxSelectBox('instance') !== undefined)
                $('#cboBlogCategory').dxSelectBox('instance').option('dataSource', blogCategoryData);
        });
    };

    self.init = function () {
        self.popupDetail = $("#popBlogCategory").dxPopup({
            fullScreen: false,
            title: 'Thông Tin Nhóm Tin Tức',
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
                            $("#popBlogCategory").dxPopup("instance").hide();
                        }
                    }
                }
            ],
            closeOnOutsideClick: function (e) {
                return e.target !== $("#popBlogCategory").get()[0];
            }
        }).dxPopup("instance");

        self.dataGrid = $("#grdBlogCategory").dxDataGrid({
            dataSource: blogCategories,
            allowColumnReordering: true,
            allowColumnResizing: true,
            columnAutoWidth: true,
            filterRow: {
                visible: true,
                showAllText: '(Tất Cả)',
                showOperationChooser: true
            },
            editing: {
                mode: 'batch',
                allowDeleting: true,
                texts: {
                    deleteRow: 'Xóa',
                    undeleteRow: 'Hủy Bỏ'
                }
            },
            onContentReady: function () {
                $("#addNewButton").remove();
                $("#reloadButton").remove();
                $("#grdBlogCategory").find('.dx-datagrid-header-panel')
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
            loadPanel: {
                text: 'Đang tải dữ liệu...'
            },
            searchPanel: {
                visible: true,
                highlightSearchText: true,
                placeholder: 'Tìm kiếm...'
            },
            paging: { pageSize: 20 },
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
                    dataField: 'blogCategoryCode',
                    caption: 'Mã nhóm',
                    dataType: 'string',
                    cellTemplate: function (container, options) {
                        $("<span class='gridbutton-arrowleft' />")
                        .text(options.text)
                        .css({ "text-decoration": "underline", "font-weight": "bold" })
                        .on('click', function () {
                            $.getJSON([url, '/', options.data.blogCategoryId].join(''), function (response) {
                                self.openForm(response.data);
                            });
                        })
                        .appendTo(container);
                    }
                },
                {
                    width: '30%',
                    dataField: 'vnName',
                    caption: 'Tên nhóm VN',
                    dataType: 'string',
                },
                {
                    width: '30%',
                    dataField: 'enName',
                    caption: 'Tên nhóm EN',
                    dataType: 'string',
                },
                {
                    width: '30%',
                    dataField: 'parent.vnName',
                    caption: 'Thuộc nhóm',
                    dataType: 'string',
                },
                {
                    width: '10%',
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

                    showMessage(data.Status, data.Message);
                });
            },
            onRowRemoved: function (info) {
                self.loadData();
            },
        }).dxDataGrid('instance');

        self.loadData();
    };

    self.getForm = function (d) {
        blogCategoryItem = d;

        blogCategoryData = [];
        if (blogCategories !== undefined && blogCategories.length > 0)
            blogCategoryData = $.grep(blogCategories, function (c) {
                if (d.blogCategoryId !== undefined)
                    return c.parentId === 0 && c.blogCategoryId !== d.blogCategoryId;
                else return c.parentId === 0;
            });
        blogCategoryData.unshift({ blogCategoryId: 0, vnName: null, enName: null });

        var form = $("<div id='categoryForm'>").dxForm({
            formData: blogCategoryItem,
            labelLocation: 'left',
            showOptionalMark: '*',
            optionalMark: '',
            scrollingEnabled: true,
            onFieldDataChanged: function (model) {
                blogCategoryItem[model.dataField] = model.value;
            },
            customizeItem: function (item) {
                switch (item.dataField) {
                    case "bloCategoryCode":
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
                                text: 'Mã nhóm tin tức'
                            },
                            dataField: 'blogCategoryCode',
                            isRequired: true,
                            editorType: 'dxTextBox',
                            template: function (data, itemElement) {
                                var textBox = $("<div id='blogCategoryCode'>");
                                textBox.dxTextBox({
                                    value: data.editorOptions.value,
                                    onValueChanged: function (e) {
                                        d["blogCategoryCode"] = getDataCode(e.value);
                                        $("#blogCategoryCode").dxTextBox("instance").option("value", getDataCode(e.value));
                                    }
                                });

                                textBox.appendTo(itemElement);
                            }
                        },
                        {
                            label: {
                                text: 'Thuộc nhóm:'
                            },
                            dataField: 'parentId',
                            editorType: 'dxSelectBox',
                            template: function (data, itemElement) {
                                var textBox = $("<div id='cboBlogCategory'>");
                                textBox.dxSelectBox({
                                    dataSource: blogCategoryData,
                                    searchEnabled: true,
                                    placeholder: 'Chọn nhóm bất kỳ',
                                    displayExpr: 'vnName',
                                    valueExpr: 'blogCategoryId',
                                    value: data.editorOptions.value,
                                    onValueChanged: function (e) {
                                        d["parentId"] = e.value;
                                    }
                                });

                                textBox.appendTo(itemElement);
                            }
                        },
                        { itemType: 'empty', colSpan: 2 },
                        {
                            label: {
                                text: 'Tên nhóm VN'
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
                                text: 'Tên nhóm EN'
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
                                        blogCategoryItem["enName"] = e.value;
                                        blogCategoryItem["enRewriteUrl"] = getRewriteUrl(e.value);
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
                                    title: 'SEO',
                                    items: [
                                        {
                                            label: {
                                                text: 'Tên nhóm VN SEO'
                                            },
                                            dataField: 'vnNameSEO',
                                            colSpan: 4
                                        },
                                        {
                                            label: {
                                                text: 'Tên nhóm EN SEO'
                                            },
                                            dataField: 'enNameSEO',
                                            colSpan: 4
                                        },
                                        {
                                            label: {
                                                text: 'Mô tả nhóm VN'
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
                                                        blogCategoryItem["vnDescription"] = e.value;
                                                    }
                                                });

                                                textArea.appendTo(itemElement);
                                            }
                                        },
                                        {
                                            label: {
                                                text: 'Mô tả nhóm EN'
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
                                                        blogCategoryItem["enDescription"] = e.value;
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
                                                        blogCategoryItem["tag"] = e.value;
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
                                                text: 'Ảnh minh họa'
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
                                                    selectButtonText: 'Chọn file ảnh',
                                                    labelText: 'Kéo thả ảnh vào đây',
                                                    multiple: false,
                                                    accept: 'image/*'
                                                });

                                                fileUploader.appendTo(itemElement);
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
                                                        blogCategoryItem["inActive"] = e.value;
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
                                                        blogCategoryItem["note"] = e.value;
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
        $("#popBlogCategory").dxPopup("instance").option('contentTemplate', function (c) {
            c.append(self.getForm(d));
        });
        $("#popBlogCategory").dxPopup("instance").show();
    };

    self.closeForm = function () {
        $("#popBlogCategory").dxPopup("instance").hide();
    }

    self.saveData = function (c) {
        if ($('#categoryForm').dxForm("instance").validate().isValid) {
            var isInsert = blogCategoryItem.blogCategoryId === undefined;
            var isCanSave = true;

            if (isInsert) {
                if (blogCategories !== undefined && blogCategories.length > 0)
                    $.each(blogCategories, function () {
                        if (this.blogCategoryCode === blogCategoryItem["blogCategoryCode"]) {
                            showMessage(false, 'Duplicate blog category information. Please try again!');
                            isCanSave = false;
                            return false;
                        }
                    });
            }
            else {
                if (blogCategories !== undefined && blogCategories.length > 0)
                    $.each(blogCategories, function () {
                        if (this.blogCategoryCode === blogCategoryItem["blogCategoryCode"] && this.blogCategoryId !== blogCategoryItem["blogCategoryId"]) {
                            showMessage(false, 'Duplicate blog category information. Please try again! update');
                            isCanSave = false;
                            return false;
                        }
                    });
            }
            if (isCanSave) {
                var _data = ko.toJSON(blogCategoryItem);
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