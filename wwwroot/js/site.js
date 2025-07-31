// Sepet işlemleri için global değişken
let cart = [];

// Sayfa yüklendiğinde çalışacak fonksiyon
document.addEventListener('DOMContentLoaded', function() {
    loadProducts();
    updateCartCount();
});

// Ürünleri yükle
async function loadProducts() {
    try {
        const response = await fetch('/api/product');
        const products = await response.json();
        displayProducts(products);
    } catch (error) {
        console.error('Ürünler yüklenirken hata oluştu:', error);
    }
}

// Ürünleri ekranda göster
function displayProducts(products) {
    const productsContainer = document.getElementById('products-container');
    if (!productsContainer) return;

    productsContainer.innerHTML = products.map(product => `
        <div class="col-md-4 mb-4">
            <div class="card h-100">
                <img src="${product.imageUrl || 'https://via.placeholder.com/150'}" class="card-img-top" alt="${product.name}">
                <div class="card-body">
                    <h5 class="card-title">${product.name}</h5>
                    <p class="card-text">${product.description || 'Açıklama yok'}</p>
                    <p class="h5 text-primary">$${product.price || '0.00'}</p>
                    <div class="input-group mb-3">
                        <input type="number" id="qty-${product.id}" class="form-control" value="1" min="1">
                        <button class="btn btn-primary" onclick="addToCart(${product.id}, '${product.name}')">
                            <i class="fas fa-cart-plus"></i> Sepete Ekle
                        </button>
                    </div>
                </div>
            </div>
        </div>
    `).join('');
}

// Sepete ürün ekle
async function addToCart(productId, productName) {
    const quantity = parseInt(document.getElementById(`qty-${productId}`).value) || 1;
    
    // Kullanıcı giriş yapmış mı kontrol et
    const userId = getCurrentUserId();
    if (!userId) {
        alert('Lütfen önce giriş yapınız!');
        window.location.href = '/giris';
        return;
    }

    try {
        const response = await fetch('/api/order', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                productId: productId,
                userId: userId,
                quantity: quantity
            })
        });

        if (response.ok) {
            // Sepeti güncelle
            const existingItem = cart.find(item => item.productId === productId);
            if (existingItem) {
                existingItem.quantity += quantity;
            } else {
                cart.push({ productId, name: productName, quantity });
            }
            
            updateCartCount();
            showAlert('success', 'Ürün sepete eklendi!');
        } else {
            throw new Error('Sipariş oluşturulamadı');
        }
    } catch (error) {
        console.error('Sepete eklerken hata oluştu:', error);
        showAlert('danger', 'Ürün sepete eklenirken bir hata oluştu!');
    }
}

// Sepet sayacını güncelle
function updateCartCount() {
    const cartCount = document.getElementById('cart-count');
    if (cartCount) {
        const totalItems = cart.reduce((sum, item) => sum + item.quantity, 0);
        cartCount.textContent = totalItems;
        cartCount.style.display = totalItems > 0 ? 'inline' : 'none';
    }
}

// Kullanıcı ID'sini getir (gerçek uygulamada session veya token'dan alınacak)
function getCurrentUserId() {
    // Bu kısmı gerçek uygulamada kullanıcı giriş sistemine göre düzenleyin
    return 1; // Örnek kullanıcı ID'si
}

// Uyarı mesajı göster
function showAlert(type, message) {
    const alertDiv = document.createElement('div');
    alertDiv.className = `alert alert-${type} alert-dismissible fade show`;
    alertDiv.role = 'alert';
    alertDiv.innerHTML = `
        ${message}
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Kapat"></button>
    `;
    
    const container = document.querySelector('.container');
    container.prepend(alertDiv);
    
    // 3 saniye sonra uyarıyı kaldır
    setTimeout(() => {
        alertDiv.remove();
    }, 3000);
}
