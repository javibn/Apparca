<template>
  <el-upload
    class="upload-demo"
    drag
    multiple
    :before-upload="beforeUpload"
    :on-success="handleSuccess"
  >
    <el-icon class="el-icon--upload"><upload-filled /></el-icon>
    <div class="el-upload__text">
      Drop file here or <em>click to upload</em>
    </div>
    <template #tip>
      <div class="el-upload__tip">
        jpg/png files with a size less than 500kb
      </div>
    </template>
  </el-upload>
  
  <ul>
    <li v-for="image in uploadedImages" :key="image.name">
      <img :src="image.url" alt="">
    </li>
  </ul>
</template>

<script setup >
import { UploadFilled } from '@element-plus/icons-vue'

let uploadedImages = []

const beforeUpload = (file) => {
  const isJPGorPNG = file.type === 'image/jpeg' || file.type === 'image/png'
  const isLt500K = file.size / 1024 < 500

  if (!isJPGorPNG) {
    this.$message.error('Image must be JPG or PNG format!')
    return false
  }
  if (!isLt500K) {
    this.$message.error('Image size can not exceed 500kb!')
    return false
  }

  return true
}

const handleSuccess = (response) => {
  uploadedImages.push(response.file)
}
</script>
