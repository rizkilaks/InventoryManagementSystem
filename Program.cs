using System;
using System.Collections.Generic;

namespace InventoryManagementSystem {
    class Item {
        public string NamaItem {get; set;}
        public string Kategori {get; set;}
        public decimal Harga {get; set;}
        public int Stok {get; set;}

        public Item(string namaItem, string kategori, decimal harga, int stok) {
            NamaItem = namaItem;
            Kategori = kategori;
            Harga = harga;
            Stok = stok;
        }
    }

    class Inventory {
        public string NamaGudang {get; set;}
        public List<Item> Items {get; set;}

        public Inventory(string namaGudang) {
            NamaGudang = namaGudang;
            Items = new List<Item>();
        }

        public void tambahItemBaru(Item itemBaru) {
            Items.Add(itemBaru);
            Console.WriteLine($"\nMenambahkan {itemBaru.NamaItem} ke gudang {NamaGudang}.");
        }

        public void updateStok(string namaItem, int stok) {
            Item updateItem = Items.Find(i => i.NamaItem == namaItem);
            if (updateItem != null) {
                updateItem.Stok += stok;
                if (stok > 0) {
                    Console.WriteLine($"\nMenambahkan stok {namaItem} sebanyak {stok} di gudang {NamaGudang}.");
                }
                else if (stok < 0) {
                    Console.WriteLine($"\nMengurangi stok {namaItem} sebanyak {Math.Abs(stok)} di gudang {NamaGudang}.");
                }

            }
        }

        public void displayItems() {
            Console.WriteLine($"\nGudang {NamaGudang}");
            if (Items.Count > 0) {
                foreach (var item in Items) {
                    Console.WriteLine($"{item.NamaItem} - {item.Kategori} - {item.Harga} - {item.Stok}");
                }
            }
            else {
                Console.WriteLine("---KOSONG---");
            }

        }

    }
    class ProgramUtama {
        static void Main() {
            Inventory Cakung = new Inventory("Cakung");
            Inventory PuloGadung = new Inventory("Pulo Gadung");

            Console.WriteLine("\nInventory Terkini:");
            Cakung.displayItems();
            PuloGadung.displayItems();

            Item apel = new Item("Apel", "Buah", 10000, 10);
            Item bayam = new Item("Bayam", "Sayuran", 3500, 20);
            Item pisang = new Item("Pisang", "Buah", 4000, 50);

            Cakung.tambahItemBaru(apel);
            Cakung.tambahItemBaru(bayam);
            Cakung.tambahItemBaru(pisang);

            Console.WriteLine("\nInventory Terkini:");
            Cakung.displayItems();
            PuloGadung.displayItems();

            Cakung.updateStok("Apel", -5);
            Cakung.updateStok("Bayam", 20);

            Console.WriteLine("\nInventory Terkini:");
            Cakung.displayItems();
            PuloGadung.displayItems();
        }
    }
}

