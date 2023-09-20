document.addEventListener("alpine:init", () => {
    Alpine.data("category", () => ({
        _list: [],
        _modal: {},

        //edit modal button
        _modalSetting: {
            title: "",
            url: "",
            primaryButtonText: ""
        },

        //edit data
        _updinData: {
            id: 0,
            name: "",
            slug: ""
        },

        init() {
            this._modal = new bootstrap.Modal("#categoryUpdinModal");
                this.$watch("_updinData.name", (newVal, oldVal) => {
                    this._updinData.slug = newVal
                        .toLowerCase()
                        .normalize("NFD")
                        .replace(/[\u0300-\u036f]/g, "")
                        .replace("đ", "d")
                        .replace(/[^a-z]/g, "-");
                });

            fetch("/Admin/Category/ListAll")
                .then(x => x.json())
                .then(json => {
                    this._list = json;
                })
                .catch(err => {
                    console.log(err);
                });
        },

        //add
        OpenModalAdd() {
            this._modal.show();
            this._modalSetting = {
                title: "Add new categories",
                url: "",
                primaryButtonText: "Create"
            }
        },

        //update
        OpenModalUpdate() {
            this._modal.show();
            this._modalSetting = {
                title: "Update categories",
                url: "",
                primaryButtonText: "Save changes"
            }
        },

        //remove
        /*DeleteData() {
            this._modal = ""
        }*/
        SaveChanges() {

        }
    }));
});