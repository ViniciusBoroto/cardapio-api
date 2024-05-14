const express = require('express')
const mongoose = require('mongoose')

const app = express()
const port = 3000
mongoose.connect('')

const Item = mongoose.model('Item', {
    name: String,
    description: String,
    price: Number,
    image_url: String
})

app.get('/', (req, res) => {
    res.send('Hello World')
})

app.post('/', async (req, res) => {
    const item = new Item({
        name: req.body.name,
        description: req.body.description,
        price: req.body.price,
        image_url: req.body.image_url
    })
    await item.save()
    res.send(item)
})

app.get('/help', (req, res) => {
    res.send('HELPPPPP')
})


app.listen(port, () => {
    console.log(`Example app listening on port ${port}`)
})